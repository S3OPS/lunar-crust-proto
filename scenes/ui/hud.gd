extends CanvasLayer
## HUD overlay displaying player stats
## Shows health, stamina, XP, and level

@onready var health_bar: ProgressBar = $MarginContainer/VBoxContainer/HealthBar
@onready var health_label: Label = $MarginContainer/VBoxContainer/HealthBar/Label
@onready var stamina_bar: ProgressBar = $MarginContainer/VBoxContainer/StaminaBar
@onready var stamina_label: Label = $MarginContainer/VBoxContainer/StaminaBar/Label
@onready var xp_bar: ProgressBar = $MarginContainer/VBoxContainer/XPBar
@onready var xp_label: Label = $MarginContainer/VBoxContainer/XPBar/Label
@onready var level_label: Label = $MarginContainer/VBoxContainer/LevelLabel

var player: Node = null


func _ready() -> void:
	# Connect to EventBus signals
	EventBus.player_health_changed.connect(_on_health_changed)
	EventBus.player_stamina_changed.connect(_on_stamina_changed)
	EventBus.player_experience_gained.connect(_on_experience_gained)
	EventBus.player_level_up.connect(_on_level_up)
	
	# Get player reference
	await get_tree().process_frame
	player = GameManager.get_player()
	
	# Initialize UI if player exists
	if player and player.stats:
		_update_all_stats()


func _update_all_stats() -> void:
	if player and player.stats:
		var stats = player.stats
		_on_health_changed(stats.current_health, stats.max_health)
		_on_stamina_changed(stats.current_stamina, stats.max_stamina)
		_on_experience_gained(0, stats.experience)
		level_label.text = "Level " + str(stats.level)


func _on_health_changed(current: float, max: float) -> void:
	if health_bar and health_label:
		health_bar.max_value = max
		health_bar.value = current
		health_label.text = "Health: %d / %d" % [int(current), int(max)]


func _on_stamina_changed(current: float, max: float) -> void:
	if stamina_bar and stamina_label:
		stamina_bar.max_value = max
		stamina_bar.value = current
		stamina_label.text = "Stamina: %d / %d" % [int(current), int(max)]


func _on_experience_gained(_amount: int, total: int) -> void:
	if player and player.stats and xp_bar and xp_label:
		var stats = player.stats
		xp_bar.max_value = stats.experience_to_next_level
		xp_bar.value = stats.experience
		xp_label.text = "XP: %d / %d" % [stats.experience, stats.experience_to_next_level]


func _on_level_up(new_level: int) -> void:
	if level_label:
		level_label.text = "Level " + str(new_level)
	
	# Update XP bar
	if player and player.stats:
		_on_experience_gained(0, player.stats.experience)
