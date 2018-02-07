extends Node

var ip = '127.0.0.1'
var SERVER_PORT = 33333
var log_label

var players = Array()

func _ready():
	log_label = get_node("Console/RichTextLabel")
	var host = NetworkedMultiplayerENet.new()
	host.create_server(SERVER_PORT, 4)
	get_tree().set_network_peer(host)
	get_tree().connect("network_peer_connected", self, "_player_connected")
	get_tree().connect("network_peer_disconnected", self, "_player_disconnected")
	get_tree().connect("connected_to_server", self, "_connected_ok")
	get_tree().connect("connection_failed", self, "_connected_fail")
	get_tree().connect("server_disconnected", self, "_server_disconnected")

func _player_connected(id):
	console_log("Player connected: " + str(id))
	players.append(id)
	console_log("Player count: " + str(players.size()))

func _player_disconnected(id):
	console_log("Player disconnected: " + str(id))
	var idx = players.find(id)
	if idx != -1:
		players.remove(idx)
	console_log("Player count: " + str(players.size()))

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

func console_log( msg ):
	var curr = log_label.text
	var txt = curr + msg + "\r\n"
	log_label.set_text(txt)
	
	
