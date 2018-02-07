extends KinematicBody2D

var animated_sprite
var is_interactable
var speed = 300
var interactable_target
var screen_size

func _ready():
	var interaction_area = get_node("Sprite/Interaction")
	interaction_area.connect("area_entered", self, "on_interaction_area_entered")
	interaction_area.connect("area_exited", self, "on_interaction_area_exited")
	screen_size = get_viewport_rect().size / 2
	animated_sprite = get_node("Sprite")

func on_interaction_area_entered( area ):
	print("interaction area entered ", area)
	interactable_target = area
	
func on_interaction_area_exited( area ):
	print("interaction area exited ", area)
	interactable_target = null
	
func is_interactable():
	return interactable_target != null

func interact():
	if not is_interactable():
		return
	var type = interactable_target.get_meta("type")
	if type == "door":
		var map = interactable_target.get_meta("dest_map")
		var x = interactable_target.get_meta("dest_tile_x")
		var y = interactable_target.get_meta("dest_tile_y")
		warp(x, y)
		
#func _process(delta):
#	# Called every frame. Delta is time since last frame.
#	# Update game logic here.
#	pass

func warp( x, y ):
	position = Vector2(x, y)
