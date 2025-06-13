var ShipAdapter = (function () {
    function ShipAdapter() {
        this._ship = new Ship();
    }
    ShipAdapter.prototype.TurnLeft = function () {
        this._ship.SetRudderAngleTo(-30);
        this._ship.SetSailAngle(3, 12);
    };
    ShipAdapter.prototype.TurnRight = function () {
        this._ship.SetRudderAngleTo(30);
        this._ship.SetSailAngle(5, -9);
    };
    ShipAdapter.prototype.GoForward = function () {
        //do something else to the _ship
    };
    return ShipAdapter;
})();

var ship = new ShipAdapter();
ship.GoForward();
ship.TurnLeft();