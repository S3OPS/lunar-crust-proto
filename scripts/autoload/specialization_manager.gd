extends Node

## SpecializationManager
## Manages combat specializations and skill trees
## Provides a progression system for players to specialize their combat style

signal specialization_chosen(spec_id: String)
signal ability_unlocked(spec_id: String, ability_id: String)

# Dictionary of all available specializations: spec_id -> SpecializationResource
var specializations: Dictionary = {}
var current_specialization: String = ""
var unlocked_abilities: Array[String] = []
var specialization_level: int = 0


func _ready() -> void:
	if OS.is_debug_build():
		print("🎯 SpecializationManager initialized")


## Register a specialization for players to choose
## @param spec: The specialization resource to register
func register_specialization(spec: SpecializationResource) -> void:
	if not spec or spec.specialization_id.is_empty():
		push_error("SpecializationManager: Cannot register specialization with empty or null ID")
		return
	
	specializations[spec.specialization_id] = spec
	if OS.is_debug_build():
		print("SpecializationManager: Specialization registered - %s" % spec.specialization_name)

## Choose a combat specialization for the player
## @param spec_id: The ID of the specialization to choose
## @return: true if specialization was successfully chosen, false otherwise
func choose_specialization(spec_id: String) -> bool:
	if spec_id not in specializations:
		push_error("SpecializationManager: Specialization not found - %s" % spec_id)
		return false
	
	if not current_specialization.is_empty():
		push_warning("SpecializationManager: Already chosen specialization - %s" % current_specialization)
		return false
	
	current_specialization = spec_id
	specialization_chosen.emit(spec_id)
	
	# Apply passive bonuses from specialization
	_apply_specialization_bonuses(spec_id)
	
	if OS.is_debug_build():
		print("SpecializationManager: Chosen specialization - %s" % specializations[spec_id].specialization_name)
	return true

## Unlock a specialization ability
## @param ability_id: The ID of the ability to unlock
## @return: true if ability was successfully unlocked, false otherwise
func unlock_ability(ability_id: String) -> bool:
	if current_specialization.is_empty():
		push_warning("SpecializationManager: No specialization chosen")
		return false
	
	var spec: SpecializationResource = specializations.get(current_specialization)
	if spec == null:
		push_error("SpecializationManager: Current specialization not found - %s" % current_specialization)
		return false
	
	if ability_id not in spec.abilities:
		push_warning("SpecializationManager: Ability not in specialization - %s" % ability_id)
		return false
	
	var required_level: int = spec.abilities[ability_id]
	if specialization_level < required_level:
		push_warning("SpecializationManager: Level %d required for ability" % required_level)
		return false
	
	if ability_id in unlocked_abilities:
		push_warning("SpecializationManager: Ability already unlocked - %s" % ability_id)
		return false
	
	unlocked_abilities.append(ability_id)
	ability_unlocked.emit(current_specialization, ability_id)
	if OS.is_debug_build():
		print("SpecializationManager: Unlocked ability - %s" % ability_id)
	return true

## Increase specialization level (called on player level up)
func increase_specialization_level() -> void:
	specialization_level += 1
	if OS.is_debug_build():
		print("SpecializationManager: Specialization level increased to %d" % specialization_level)


## Apply passive bonuses from specialization to player stats
## @param spec_id: The ID of the specialization whose bonuses to apply
func _apply_specialization_bonuses(spec_id: String) -> void:
	var spec: SpecializationResource = specializations[spec_id]
	
	# Apply bonuses to player stats through GameManager
	# Note: Bonuses are currently logged only; full integration requires
	# extended CharacterStats properties for attack/defense modifiers
	if GameManager.has_valid_player() and GameManager.player_stats:
		# Future enhancement: Add attack_modifier and defense_modifier to CharacterStats
		# GameManager.player_stats.attack_modifier += spec.attack_bonus
		# GameManager.player_stats.defense_modifier += spec.defense_bonus
		pass
	
	if OS.is_debug_build():
		print("SpecializationManager: Specialization ready - +%d attack, +%d defense (bonus tracking pending full stats integration)" % [spec.attack_bonus, spec.defense_bonus])

## Get a specialization by ID
## @param spec_id: The ID of the specialization to retrieve
## @return: The SpecializationResource or null if not found
func get_specialization(spec_id: String) -> SpecializationResource:
	return specializations.get(spec_id, null)


## Get the current active specialization
## @return: The current SpecializationResource or null if none chosen
func get_current_specialization() -> SpecializationResource:
	if current_specialization.is_empty():
		return null
	return specializations.get(current_specialization, null)


## Check if player has unlocked an ability
## @param ability_id: The ID of the ability to check
## @return: true if ability is unlocked, false otherwise
func has_ability(ability_id: String) -> bool:
	return ability_id in unlocked_abilities


## Save specialization data for persistence
## @return: Dictionary containing all specialization data
func save_data() -> Dictionary:
	return {
		"current_specialization": current_specialization,
		"unlocked_abilities": unlocked_abilities,
		"specialization_level": specialization_level
	}


## Load specialization data from save
## @param data: Dictionary containing specialization data
func load_data(data: Dictionary) -> void:
	current_specialization = data.get("current_specialization", "")
	unlocked_abilities = data.get("unlocked_abilities", [])
	specialization_level = data.get("specialization_level", 0)
	
	# Reapply bonuses if a specialization was chosen
	if not current_specialization.is_empty():
		_apply_specialization_bonuses(current_specialization)
