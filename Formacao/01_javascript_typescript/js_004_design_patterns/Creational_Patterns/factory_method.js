var Religion = Religion || {};

var WateryGod = (function () {
    function WateryGod() { }
    WateryGod.prototype.prayTo = function () {
        console.log("Orando para: WateryGod");
    };
    return WateryGod;
})();
Religion.WateryGod = WateryGod;

var AncientGods = (function () {
    function AncientGods() { }
    AncientGods.prototype.prayTo = function () {
        console.log("Orando para: AncientGods");
    };
    return AncientGods;
})();
Religion.AncientGods = AncientGods;

var DefaultGod = (function () {
    function DefaultGod() { }
    DefaultGod.prototype.prayTo = function () {
        console.log("Orando para: DefaultGod");
    };
    return DefaultGod;
})();
Religion.DefaultGod = DefaultGod;

var GodFactory = (function () {
    function GodFactory() { }
    GodFactory.Build = function (godName) {
        switch (godName) {
            case "watery":
                return new WateryGod();
                break;
            case "ancient":
                return new AncientGods();
                break;
            default:
                return new DefaultGod();
                break;
        };
    }
    return GodFactory;
})();

var GodDeterminant = (function () {
    function GodDeterminant(religionName, prayerPurpose) {
        this.religionName = religionName;
        this.prayerPurpose = prayerPurpose;
    }
    return GodDeterminant;
})();

var Prayer = (function () {
    function Prayer() { }
    Prayer.prototype.pray = function (godName) {
        GodFactory.Build(godName).prayTo();
    };
    return Prayer;
})();

// Exemplo 1: Orar para o WateryGod
var prayer1 = new Prayer();
prayer1.pray("watery"); // Deve chamar WateryGod().prayTo()

// Exemplo 2: Orar para o AncientGod
var prayer2 = new Prayer();
prayer2.pray("ancient"); // Deve chamar AncientGods().prayTo()

// Exemplo 3: Orar para um deus desconhecido (usa DefaultGod)
var prayer3 = new Prayer();
prayer3.pray("unknown"); // Deve chamar DefaultGod().prayTo()