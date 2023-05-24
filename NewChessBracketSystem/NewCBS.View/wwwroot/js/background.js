
function createSquares() {
    const container = document.getElementById('container');
    const overlay = document.getElementById('overlay');

    const containerWidth = container.offsetWidth;
    const containerHeight = container.offsetHeight;

    const rows = 6;
    const columns = 10;
    const squareWidth = containerWidth / columns;
    const squareHeight = containerHeight / rows;

    console.log(squareHeight + " | " + squareWidth)

    const table = [
        [1, 1, 1, 1, 1, 0, 1, 1, 0, 1],
        [1, 1, 1, 1, 0, 1, 0, 0, 1, 0],
        [1, 1, 1, 1, 1, 0, 0, 0, 0, 0],
        [1, 1, 1, 1, 1, 0, 0, 0, 0, 0],
        [1, 1, 1, 1, 0, 1, 0, 0, 1, 0],
        [1, 1, 1, 1, 1, 1, 1, 1, 1, 0],
    ]

    for (let row = 0; row < rows; row++) {
        for (let col = 0; col < columns; col++) {
            if (table[row][col] === 1) {
                const square = document.createElement('div');
                square.classList.add('square');
                square.style.width = `${squareWidth}px`;
                square.style.height = `${squareHeight}px`;

                const left = col * squareWidth;
                const top = row * squareHeight;

                square.style.left = `${left}px`;
                square.style.top = `${top}px`;

                overlay.appendChild(square);
            }
        }
    }
}

function createBox() {
    const container = document.getElementById('container');
    const overlay = document.getElementById('overlay');

    console.log(container);
    console.log(overlay);

    const containerWidth = container.offsetWidth;
    const containerHeight = container.offsetHeight;

    const square = document.createElement('div');
    square.classList.add('square');
    square.style.width = `${containerWidth}px`;
    square.style.height = `${containerHeight}px`;

    overlay.appendChild(square);
}