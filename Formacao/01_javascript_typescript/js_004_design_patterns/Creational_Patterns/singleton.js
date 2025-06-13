var Westeros;
(function (Westeros) {
    var Wall = (function () {
        function Wall() {
            this.height = 0;
            if (Wall._instance) return Wall._instance;
            Wall._instance = this;
        }
        Wall.prototype.setHeight = function (height) {
            this.height = height;
        };
        Wall.prototype.getStatus = function () {
            console.log("Wall is " + this.height + " meters tall");
        };
        Wall.getInstance = function () {
            if (!Wall._instance) {
                Wall._instance = new Wall();
            }
            return Wall._instance;
        };
        Wall._instance = null;
        return Wall;
    })();
    Westeros.Wall = Wall;
})(Westeros || (Westeros = {}));