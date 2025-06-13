var Westeros;
(function (Westeros) {
    var Ruler = (function () {
        function Ruler() {

            this.house = new Westeros.Houses.Targaryen(); //forte acoplamento
        }
        return Ruler;
    })();
    Westeros.Ruler = Ruler;
})(Westeros || (Westeros = {}));

var ruler = Westeros.Ruler;
