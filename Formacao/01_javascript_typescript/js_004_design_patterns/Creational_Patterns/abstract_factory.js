// Personagens Lannister
var KingJoffery = (function () {
    function KingJoffery() { }
    KingJoffery.prototype.makeDecision = function () {
        console.log("King Joffrey makes a decision.");
    };
    return KingJoffery;
})();

var LordTywin = (function () {
    function LordTywin() { }
    LordTywin.prototype.makeDecision = function () {
        console.log("Lord Tywin makes a decision.");
    };
    return LordTywin;
})();

// Fábrica Lannister
var LannisterFactory = (function () {
    function LannisterFactory() { }
    LannisterFactory.prototype.getKing = function () {
        return new KingJoffery();
    };
    LannisterFactory.prototype.getHandOfTheKing = function () {
        return new LordTywin();
    };
    return LannisterFactory;
})();

// Personagens Targaryen (precisavam ser definidos)
var KingAerys = (function () {
    function KingAerys() { }
    KingAerys.prototype.makeDecision = function () {
        console.log("King Aerys makes a decision.");
    };
    return KingAerys;
})();

var LordConnington = (function () {
    function LordConnington() { }
    LordConnington.prototype.makeDecision = function () {
        console.log("Lord Connington makes a decision.");
    };
    return LordConnington;
})();

// Fábrica Targaryen
var TargaryenFactory = (function () {
    function TargaryenFactory() { }
    TargaryenFactory.prototype.getKing = function () {
        return new KingAerys();
    };
    TargaryenFactory.prototype.getHandOfTheKing = function () {
        return new LordConnington();
    };
    return TargaryenFactory;
})();

// Sessão da Corte
var CourtSession = (function () {
    function CourtSession(abstractFactory) {
        this.abstractFactory = abstractFactory;
        this.COMPLAINT_THRESHOLD = 10;
    }

    CourtSession.prototype.complaintPresented = function (complaint) {
        if (complaint.severity < this.COMPLAINT_THRESHOLD) {
            this.abstractFactory.getHandOfTheKing().makeDecision();
        } else {
            this.abstractFactory.getKing().makeDecision();
        }
    };

    return CourtSession;
})();

// Executando
var courtSession1 = new CourtSession(new TargaryenFactory());
courtSession1.complaintPresented({ severity: 8 });
courtSession1.complaintPresented({ severity: 12 });

var courtSession2 = new CourtSession(new LannisterFactory());
courtSession2.complaintPresented({ severity: 9 });
courtSession2.complaintPresented({ severity: 13 });