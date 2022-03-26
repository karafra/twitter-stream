// Stack containing all id of currently displayed elements
let stack = [];

/**
 * Creates random identifier;
 */
const createId = () => "id" + new Date().getTime();

/**
 * Static implementation of callback called on message received
 *
 * @param {MessageEvent} message
 */
const onMessage = (message) => {
  let id;
  if (stack.length == 40) {
    const id = stack.shift();
    try {
      document.getElementById(id).remove();
    } catch (err) {}
  }
  id = createId();
  const div = createDiv(message.data, id);
  placeDiv(div);
  stack.push(id);
};

/**
 * Called when connection to socket opens.
 *
 * @returns void
 */
const onClose = () => console.log("Connection to tweet stream closed");

/**
 * Called when connection to socket closes.
 *
 * @returns void
 */
const onOpen = () => console.log("Connection to tweet stream opened");

/**
 * Class handling connection to stream websocket.
 *
 * @author Karafra
 */
class StreamWebSocket extends WebSocket {
  constructor() {
    super("ws://localhost:5000/tweetStream/");
    this.onmessage = onMessage;
    this.onclose = onClose;
    this.onopen = onOpen;
  }
}

// Create socket
const socket = new StreamWebSocket();

// Close socket before closing window
window.onbeforeunload = (window) => socket.close();
