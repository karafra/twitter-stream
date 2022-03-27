const $main = $("#main");

/**
 * Creates html div inside which tweets are housed.
 *
 * @param {string} text
 * @returns
 */
const createDiv = (author, text, id) => {
  const template = `
    <div id="${id}" class="message">
        <div class="header">
            ${author}
        </div>
        
        <div class="content">
            ${text}    
        </div>
    </div>`;
    let main = document.createElement("div");

    
  main.innerHTML += template.trim();
  return main.childNodes[main.childElementCount - 1];
};

const createImageHolder = (mediaArr) => {
  let template = "";
  for (const link of mediaArr) {
    template.concat(`<img src=${link}> </img>\n`)  
  }
  return template;
}

const createDivWithMedia = (author, text, mediaArr, id) => {
    const template = `
    <div id="${id}" class="message">
        <div class="header">
            ${author}
        </div>
        
        <div class="content">
            ${text}
            ${createImageHolder(mediaArr)}    
        </div>
    </div>`;
  return template;
} 

/**
 * Places div somewhere on the screen.
 *
 * @param {HtmlElement} div
 */
const placeDiv = (div) => {
  $div = $(div);
  $div.fadeOut(10_000, function () {
    var maxLeft = $(window).width() - $div.width() - 25; // substract padding
    var maxTop = $(window).height() - $div.height() - 100; // substract padding
    var leftPos = Math.floor(Math.random() * (maxLeft + 1));
    var topPos = Math.floor(Math.random() * (maxTop + 1));
    $div.css({ left: leftPos, top: topPos}).fadeIn(1000);
    $div.hide().appendTo("#main").fadeIn(1000);
  });
  try {
    $div.remove();
  } catch (exp) {}
};
