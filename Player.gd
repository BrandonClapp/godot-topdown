extends "res://Character.gd"

var velocity = Vector2()

func _ready():
	pass
	
func _process(delta):
	process_movement(delta)
	process_interaction()
	
func process_movement( delta ):
	if Input.is_action_pressed("ui_up"):
		velocity = Vector2(0, -1)
	elif Input.is_action_pressed("ui_down"):
		velocity = Vector2(0, 1)
	elif Input.is_action_pressed("ui_left"):
		velocity = Vector2(-1, 0)
	elif Input.is_action_pressed("ui_right"):
		velocity = Vector2(1, 0)
	else:
		velocity = Vector2()
		
	if velocity.x > 0:
		animated_sprite.rotation_degrees = 0
	elif velocity.x < 0:
		animated_sprite.rotation_degrees = -180
	elif velocity.y > 0:
		animated_sprite.rotation_degrees = 90
	elif velocity.y < 0:
		animated_sprite.rotation_degrees = -90
		
	var new_pos = delta * speed * velocity
	move_and_collide(new_pos)

func process_interaction():
	if Input.is_action_just_pressed("ui_interact") and is_interactable():
		interact()

