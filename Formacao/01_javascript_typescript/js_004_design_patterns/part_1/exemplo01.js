var Castle = function (name) {
    this.name = name;
};

Castle.prototype.build = function () {
    console.log(this.name);
};

var instance1 = new Castle('Winterfell');
var instance2 = new Castle("Jsprototype");

Castle.prototype.build = function () {
    console.log("->" + this.name.replace('Winterfell', 'Moat Cailin 3'));
};

instance1.build();
instance2.build();

var instance3 = Object.create(Castle.prototype, {
    name: { value: "InterrFell", writable: false }
});

instance3.build();
instance3.name = "Highgarden";
instance3.build();

