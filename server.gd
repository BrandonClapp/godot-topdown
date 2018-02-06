extends Node

# class member variables go here, for example:
# var a = 2
# var b = "textvar"
var ip = '127.0.0.1'
var SERVER_PORT = 33333

func _ready():
	var host = NetworkedMultiplayerENet.new()
	host.create_server(SERVER_PORT, 4)
	get_tree().set_network_peer(host)
	get_tree().connect("network_peer_connected", self, "_player_connected")
	get_tree().connect("network_peer_disconnected", self, "_player_disconnected")
	get_tree().connect("connected_to_server", self, "_connected_ok")
	get_tree().connect("connection_failed", self, "_connected_fail")
	get_tree().connect("server_disconnected", self, "_server_disconnected")
# Player info, associate ID to data
var player_info = {}
# Info we send to other players
var my_info = { name = "Johnson Magenta", favorite_color = Color8(255, 0, 255) }

func _player_connected(id):
    print('player connected')

func _player_disconnected(id):
    print('player dc')

func _connected_ok():
    print('connected ok')

func _server_disconnected():
    print('server dc')

func _connected_fail():
    print('connect fail')

#func _process(delta):
#	# Called every frame. Delta is time since last frame.
#	# Update game logic here.
#	pass
