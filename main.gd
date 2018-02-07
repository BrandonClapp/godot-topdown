extends Node

# class member variables go here, for example:
# var a = 2
# var b = "textvar"
var ip = '127.0.0.1'
var SERVER_PORT = 33333

func _ready():
	var host = NetworkedMultiplayerENet.new()
	host.create_client(ip, SERVER_PORT)
	get_tree().set_network_peer(host)

#func _process(delta):
#	# Called every frame. Delta is time since last frame.
#	# Update game logic here.
#	pass
