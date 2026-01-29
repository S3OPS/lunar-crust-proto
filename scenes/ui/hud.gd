extends CanvasLayer
## HUD overlay displaying player stats
## Shows health, stamina, XP, and level with real-time updates

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
	if EventBus.player_health_changed.connect(_on_health_changed) != OK:
		push_error("Failed to connect player_health_changed signal")
	if EventBus.player_stamina_changed.connect(_on_stamina_changed) != OK:
		push_error("Failed to connect player_stamina_changed signal")
	if EventBus.player_experience_gained.connect(_on_experience_gained) != OK:
		push_error("Failed to connect player_experience_gained signal")
	if EventBus.player_level_up.connect(_on_level_up) != OK:
		push_error("Failed to connect player_level_up signal")
	
	# Get player reference
	await get_tree().process_frame
	player = GameManager.get_player()
	
	# Initialize UI if player exists
	if _validate_player():
		_update_all_stats()
	else:
		push_warning("HUD: Player not found or invalid stats")


## Validate that player and stats exist
func _validate_player() -> bool:
	return player != null and is_instance_valid(player) and player.stats != null


## Update all UI elements with current stats
func _update_all_stats() -> void:
	if not _validate_player():
		return
	
	var stats = player.stats
	_update_health_bar(stats.current_health, stats.max_health)
	_update_stamina_bar(stats.current_stamina, stats.max_stamina)
	_update_experience_bar(stats.experience, stats.experience_to_next_level)
	_update_level_label(stats.level)


## Update health bar and label
func _update_health_bar(current: float, maximum: float) -> void:
	if not health_bar or not health_label:
		return
	
	health_bar.max_value = maximum
	health_bar.value = current
	health_label.text = "Health: %d / %d" % [int(current), int(maximum)]


## Update stamina bar and label
func _update_stamina_bar(current: float, maximum: float) -> void:
	if not stamina_bar or not stamina_label:
		return
	
	stamina_bar.max_value = maximum
	stamina_bar.value = current
	stamina_label.text = "Stamina: %d / %d" % [int(current), int(maximum)]


## Update experience bar and label
func _update_experience_bar(current: int, maximum: int) -> void:
	if not xp_bar or not xp_label:
		return
	
	xp_bar.max_value = maximum
	xp_bar.value = current
	xp_label.text = "XP: %d / %d" % [current, maximum]


## Update level label
func _update_level_label(level: int) -> void:
	if not level_label:
		return
	
	level_label.text = "Level %d" % level


## Signal handler for health changes
func _on_health_changed(current: float, maximum: float) -> void:
	_update_health_bar(current, maximum)


## Signal handler for stamina changes
func _on_stamina_changed(current: float, maximum: float) -> void:
	_update_stamina_bar(current, maximum)


## Signal handler for experience gained
func _on_experience_gained(_amount: int, _total: int) -> void:
	if not _validate_player():
		return
	
	var stats = player.stats
	_update_experience_bar(stats.experience, stats.experience_to_next_level)


## Signal handler for level up
func _on_level_up(new_level: int) -> void:
	_update_level_label(new_level)
	
	# Update XP bar after level up
	if _validate_player():
		_update_experience_bar(player.stats.experience, player.stats.experience_to_next_level)
