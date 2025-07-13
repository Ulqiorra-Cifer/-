const canvas = document.getElementById("snakeGame");
const ctx = canvas.getContext("2d");

const scale = 20; 
const rows = canvas.height / scale;
const columns = canvas.width / scale;

let snake;
let fruit;

(function setup() {
  snake = new Snake();
  fruit = new Fruit();
  window.setInterval(gameLoop, 100);
})();

function gameLoop() {
  ctx.clearRect(0, 0, canvas.width, canvas.height);

  snake.update();
  snake.draw();

  fruit.draw();

  if (snake.eat(fruit)) {
    fruit.randomizePosition();
  }

  if (snake.checkCollision()) {
    resetGame();
  }
}

function resetGame() {
  snake = new Snake();
  fruit = new Fruit();
}

document.addEventListener("keydown", e => {
  if (e.keyCode == 37 && snake.direction !== "right") {
    snake.changeDirection("left");
  } else if (e.keyCode == 38 && snake.direction !== "down") {
    snake.changeDirection("up");
  } else if (e.keyCode == 39 && snake.direction !== "left") {
    snake.changeDirection("right");
  } else if (e.keyCode == 40 && snake.direction !== "up") {
    snake.changeDirection("down");
  }
});

function Snake() {
  this.body = [{ x: 5, y: 5 }];
  this.direction = "right";
  this.size = 1;

  this.draw = function () {
    ctx.fillStyle = "green";
    for (let i = 0; i < this.body.length; i++) {
      ctx.fillRect(this.body[i].x * scale, this.body[i].y * scale, scale, scale);
    }
  };

  this.update = function () {
    const head = { ...this.body[0] };

    if (this.direction === "up") head.y -= 1;
    if (this.direction === "down") head.y += 1;
    if (this.direction === "left") head.x -= 1;
    if (this.direction === "right") head.x += 1;

    this.body.unshift(head);
    if (this.body.length > this.size) {
      this.body.pop();
    }
  };

  this.changeDirection = function (newDirection) {
    this.direction = newDirection;
  };

  this.eat = function (fruit) {
    const head = this.body[0];
    if (head.x === fruit.position.x && head.y === fruit.position.y) {
      this.size += 1;
      return true;
    }
    return false;
  };

  this.checkCollision = function () {
    const head = this.body[0];

    if (head.x < 0 || head.x >= columns || head.y < 0 || head.y >= rows) {
      return true;
    }

    for (let i = 1; i < this.body.length; i++) {
      if (head.x === this.body[i].x && head.y === this.body[i].y) {
        return true;
      }
    }

    return false;
  };
}

function Fruit() {
  this.position = { x: 10, y: 10 };

  this.randomizePosition = function () {
    this.position = {
      x: Math.floor(Math.random() * columns),
      y: Math.floor(Math.random() * rows),
    };
  };

  this.draw = function () {
    ctx.fillStyle = "red";
    ctx.fillRect(this.position.x * scale, this.position.y * scale, scale, scale);
  };
}
