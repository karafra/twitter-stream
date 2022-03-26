const $main = $("#main");

/**
 * Creates html div inside which tweets are housed.
 *
 * @param {string} text
 * @returns
 */
const createDiv = (text, id) => {
  const template = `
    <div id="${id}" class="message">
        <div class="header">
            Header
        </div>
        
        <div class="content">
            ${text}    
        </div>
    </div>`;
    let main = document.createElement("div");

    
  main.innerHTML += template.trim();
  return main.childNodes[main.childElementCount - 1];
};

/**
 * Places div somewhere on the screen.
 *
 * @param {HtmlElement} div
 */
const placeDiv = (div) => {
  $div = $(div);
  $div.fadeOut(5000, function () {
    var maxLeft = $(window).width() - $div.width() - 15; // substract padding
    var maxTop = $(window).height() - $div.height() - 100; // substract padding
    var leftPos = Math.floor(Math.random() * (maxLeft + 1));
    var topPos = Math.floor(Math.random() * (maxTop + 1));
    $div.css({ left: leftPos, top: topPos}).fadeIn(1);
    $main.append($div);
  });
  try {
    $div.remove();
  } catch (exp) {}
};
