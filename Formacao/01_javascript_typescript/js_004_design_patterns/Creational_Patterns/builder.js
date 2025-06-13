var Westeros = Westeros || {};

var Event = (function () {
    function Event(name) {
        this.name = name;
    }
    return Event;
})();

Westeros.Event = Event;

var Prize = (function () {
    function Prize(name) {
        this.name = name;
    }
    return Prize;
})();

Westeros.Prize = Prize;

var Attendee = (function () {
    function Attendee(name) {
        this.name = name;
    }
    return Attendee;
})();
Westeros.Attendee = Attendee;

var Tournament = (function () {
    function Tournament() {
        this.events = [];
        this.attendees = [];
        this.prizes = [];
    }
    return Tournament;
})();
Westeros.Tournament = Tournament;

var LannisterTournamentBuilder = (function () {
    function LannisterTournamentBuilder() { }
    LannisterTournamentBuilder.prototype.build = function () {
        var tournament = new Tournament();
        tournament.events.push(new Event("Joust"));
        tournament.events.push(new Event("Melee"));
        tournament.attendees.push(new Attendee("Jamie"));
        tournament.prizes.push(new Prize("Gold"));
        tournament.prizes.push(new Prize("More Gold"));

        return tournament;
    };
    return LannisterTournamentBuilder;
})();
Westeros.LannisterTournamentBuilder = LannisterTournamentBuilder;

var BaratheonTournamentBuilder = (function () {
    function BaratheonTournamentBuilder() { }
    BaratheonTournamentBuilder.prototype.build = function () {
        var tournament = new Tournament();
        tournament.events.push(new Event("Joust"));
        tournament.events.push(new Event("Melee"));
        tournament.attendees.push(new Attendee("Stannis"));
        tournament.attendees.push(new Attendee("Robert"));
        return tournament;
    }
    return BaratheonTournamentBuilder;
})();
Westeros.BaratheonTournamentBuilder = BaratheonTournamentBuilder;

var TournamentBuilder = (function () {
    function TournamentBuilder() { }
    TournamentBuilder.prototype.build = function (builder) {
        return builder.build();
    };
    return TournamentBuilder;
})();
Westeros.TournamentBuilder = TournamentBuilder;

// 1. Criar o diretor (TournamentBuilder)
var director = new Westeros.TournamentBuilder();

// 2. Escolher um builder concreto (ex: Lannister ou Baratheon)
var builder = new Westeros.LannisterTournamentBuilder();

// 3. Construir o torneio
var tournament = director.build(builder);

// 4. Verificar conteúdo do torneio construído
console.log("Eventos:", tournament.events.map(e => e.name));
console.log("Participantes:", tournament.attendees.map(a => a.name));
console.log("Prêmios:", tournament.prizes ? tournament.prizes.map(p => p.name) : []);