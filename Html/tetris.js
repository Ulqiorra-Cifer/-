const canvas = document.getElementById('gameCanvas');
const context = canvas.getContext('2d');
const grid = 32;
const tetrominoSequence = [];

const tetrominos = {
    'I': [[1, 1, 1, 1]],
    'J': [[1, 0, 0], [1, 1, 1]],
    'L': [[0, 0, 1], [1, 1, 1]],
    'O': [[1, 1], [1, 1]],
    'S': [[0, 1, 1], [1, 1, 0]],
    'T': [[0, 1, 0], [1, 1, 1]],
    'Z': [[1, 1, 0], [0, 1, 1]]
};

const colors = {
    'I': 'cyan', 'O': 'yellow', 'T': 'purple',
    'S': 'green', 'Z': 'red', 'J': 'blue', 'L': 'orange'
};

const playfield = Array.from({ length: 20 }, () => Array(10).fill(0));

function getRandomTetromino() {
    const names = Object.keys(tetrominos);
    const name = names[Math.floor(Math.random() * names.length)];
    const matrix = tetrominos[name];
    return { name, matrix, row: -1, col: Math.floor(10 / 2) - Math.floor(matrix[0].length / 2) };
}

let tetromino = getRandomTetromino();

function drawPlayfield() {
    context.clearRect(0, 0, canvas.width, canvas.height);
    playfield.forEach((row, y) => {
        row.forEach((cell, x) => {
            if (cell) {
                context.fillStyle = colors[cell];
                context.fillRect(x * grid, y * grid, grid - 1, grid - 1);
            }
        });
    });
}

function drawTetromino() {
    context.fillStyle = colors[tetromino.name];
    tetromino.matrix.forEach((row, y) => {
        row.forEach((cell, x) => {
            if (cell) {
                context.fillRect((tetromino.col + x) * grid, (tetromino.row + y) * grid, grid - 1, grid - 1);
            }
        });
    });
}

function updateGame() {
    tetromino.row++;
    drawPlayfield();
    drawTetromino();
    requestAnimationFrame(updateGame);
}

document.addEventListener('keydown', (event) => {
    if (event.key === 'ArrowLeft') tetromino.col--;
    if (event.key === 'ArrowRight') tetromino.col++;
});

updateGame();
