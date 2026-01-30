extends Node

## AccessibilityManager
## Manages accessibility settings and options to improve game experience for all players
## Provides visual, audio, input, and gameplay accessibility features

signal accessibility_setting_changed(setting_name: String, value: Variant)

# Accessibility settings with default values
var settings: Dictionary = {
	# Visual Settings
	"colorblind_mode": "none",  # Options: none, protanopia, deuteranopia, tritanopia
	"high_contrast": false,
	"text_size": 1.0,  # Range: 0.8 - 1.5
	"subtitles_enabled": true,
	"subtitles_size": 1.0,
	"reduce_motion": false,
	"screen_shake": true,
	
	# Audio Settings
	"master_volume": 1.0,
	"music_volume": 0.8,
	"sfx_volume": 1.0,
	"voice_volume": 1.0,
	"audio_cues_enabled": false,  # Additional audio feedback for important events
	
	# Input Settings
	"mouse_sensitivity": 1.0,
	"gamepad_sensitivity": 1.0,
	"invert_y_axis": false,
	"hold_to_sprint": false,  # false = toggle sprint
	"auto_aim_assist": false,
	"button_remapping": {},
	
	# Gameplay Settings
	"auto_save_frequency": 300,  # seconds (5 minutes)
	"combat_auto_lock": false,
	"damage_numbers": true,
	"quest_markers": true,
	"tutorial_hints": true
}


func _ready() -> void:
	if OS.is_debug_build():
		print("♿ AccessibilityManager initialized")

## Set an accessibility setting
## @param setting_name: Name of the setting to change
## @param value: New value for the setting
func set_setting(setting_name: String, value: Variant) -> void:
	if setting_name not in settings:
		push_error("AccessibilityManager: Unknown setting - %s" % setting_name)
		return
	
	settings[setting_name] = value
	accessibility_setting_changed.emit(setting_name, value)
	_apply_setting(setting_name, value)
	
	if OS.is_debug_build():
		print("AccessibilityManager: Setting changed - %s = %s" % [setting_name, str(value)])


## Get an accessibility setting value
## @param setting_name: Name of the setting to retrieve
## @return: The setting value or null if not found
func get_setting(setting_name: String) -> Variant:
	return settings.get(setting_name, null)

## Apply a setting change immediately
## @param setting_name: Name of the setting to apply
## @param value: Value to apply
func _apply_setting(setting_name: String, value: Variant) -> void:
	match setting_name:
		"colorblind_mode":
			_apply_colorblind_mode(value as String)
		"high_contrast":
			_apply_high_contrast(value as bool)
		"text_size":
			_apply_text_size(value as float)
		"reduce_motion":
			_apply_reduce_motion(value as bool)
		"screen_shake":
			_apply_screen_shake(value as bool)
		"master_volume":
			_apply_volume("Master", value as float)
		"music_volume":
			_apply_volume("Music", value as float)
		"sfx_volume":
			_apply_volume("SFX", value as float)
		"voice_volume":
			_apply_volume("Voice", value as float)
		"mouse_sensitivity":
			_apply_mouse_sensitivity(value as float)
		_:
			pass  # Setting will be used when needed


## Apply colorblind shader/filters
## @param mode: Colorblind mode to apply (none, protanopia, deuteranopia, tritanopia)
func _apply_colorblind_mode(mode: String) -> void:
	# Future: Apply shader when rendering system is implemented
	if OS.is_debug_build():
		print("AccessibilityManager: Colorblind mode - %s" % mode)


## Apply high contrast theme
## @param enabled: Whether high contrast is enabled
func _apply_high_contrast(enabled: bool) -> void:
	# Future: Apply high contrast UI theme
	if OS.is_debug_build():
		print("AccessibilityManager: High contrast - %s" % str(enabled))


## Apply text size scaling
## @param size: Text size multiplier (0.8 - 1.5)
func _apply_text_size(size: float) -> void:
	# Future: Scale all UI text
	if OS.is_debug_build():
		print("AccessibilityManager: Text size - %s" % str(size))


## Reduce or disable motion effects
## @param enabled: Whether motion reduction is enabled
func _apply_reduce_motion(enabled: bool) -> void:
	# Future: Disable camera shake, reduce animations
	if OS.is_debug_build():
		print("AccessibilityManager: Reduce motion - %s" % str(enabled))


## Enable or disable screen shake effects
## @param enabled: Whether screen shake is enabled
func _apply_screen_shake(enabled: bool) -> void:
	# Future: Control camera shake effects
	if OS.is_debug_build():
		print("AccessibilityManager: Screen shake - %s" % str(enabled))


## Apply audio volume to specified bus
## @param bus_name: Name of the audio bus
## @param volume: Linear volume value (0.0 - 1.0)
func _apply_volume(bus_name: String, volume: float) -> void:
	var bus_idx: int = AudioServer.get_bus_index(bus_name)
	if bus_idx >= 0:
		AudioServer.set_bus_volume_db(bus_idx, linear_to_db(volume))
	else:
		push_warning("AccessibilityManager: Audio bus '%s' not found (invalid index: %d)" % [bus_name, bus_idx])


## Apply mouse sensitivity setting
## @param sensitivity: Mouse sensitivity multiplier
func _apply_mouse_sensitivity(sensitivity: float) -> void:
	# Future: Update player camera controller
	if OS.is_debug_build():
		print("AccessibilityManager: Mouse sensitivity - %s" % str(sensitivity))

## Apply a preset accessibility configuration
## @param preset_name: Name of the preset to apply
func apply_preset(preset_name: String) -> void:
	match preset_name:
		"high_visibility":
			set_setting("high_contrast", true)
			set_setting("text_size", 1.3)
			set_setting("subtitles_size", 1.3)
			set_setting("damage_numbers", true)
			set_setting("quest_markers", true)
		"low_vision":
			set_setting("text_size", 1.5)
			set_setting("subtitles_size", 1.5)
			set_setting("audio_cues_enabled", true)
			set_setting("high_contrast", true)
		"motion_sensitive":
			set_setting("reduce_motion", true)
			set_setting("screen_shake", false)
			set_setting("mouse_sensitivity", 0.7)
		"easy_controls":
			set_setting("hold_to_sprint", false)
			set_setting("auto_aim_assist", true)
			set_setting("combat_auto_lock", true)
		_:
			push_warning("AccessibilityManager: Unknown preset - %s" % preset_name)


## Reset all settings to their default values
func reset_to_defaults() -> void:
	settings = {
		"colorblind_mode": "none",
		"high_contrast": false,
		"text_size": 1.0,
		"subtitles_enabled": true,
		"subtitles_size": 1.0,
		"reduce_motion": false,
		"screen_shake": true,
		"master_volume": 1.0,
		"music_volume": 0.8,
		"sfx_volume": 1.0,
		"voice_volume": 1.0,
		"audio_cues_enabled": false,
		"mouse_sensitivity": 1.0,
		"gamepad_sensitivity": 1.0,
		"invert_y_axis": false,
		"hold_to_sprint": false,
		"auto_aim_assist": false,
		"button_remapping": {},
		"auto_save_frequency": 300,
		"combat_auto_lock": false,
		"damage_numbers": true,
		"quest_markers": true,
		"tutorial_hints": true
	}
	
	# Apply all default settings
	for setting_name in settings:
		_apply_setting(setting_name, settings[setting_name])
	
	if OS.is_debug_build():
		print("AccessibilityManager: Reset all settings to defaults")


## Save accessibility settings for persistence
## @return: Dictionary containing all settings
func save_data() -> Dictionary:
	return {
		"settings": settings
	}


## Load accessibility settings from save data
## @param data: Dictionary containing saved settings
func load_data(data: Dictionary) -> void:
	var saved_settings: Dictionary = data.get("settings", {})
	
	for setting_name in saved_settings:
		if setting_name in settings:
			settings[setting_name] = saved_settings[setting_name]
			_apply_setting(setting_name, settings[setting_name])
