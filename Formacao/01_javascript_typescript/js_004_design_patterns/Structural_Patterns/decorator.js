var BasicArmor = (function () {
    function BasicArmor() { }
    BasicArmor.prototype.CalculateDamageFromHit = function () {
        return 1;
    };
    BasicArmor.prototype.GetArmorIntegrity = function () {
        return 1;
    };
    return BasicArmor;
})();

var ChainMail = (function () {
    function ChainMail(decoratedArmor) {
        this.decoratedArmor = decoratedArmor;
    }
    ChainMail.prototype.CalculateDamageFromHit = function (hit) {
        hit.Strength = hit.Strength * .8;
        return this.decoratedArmor.CalculateDamageFromHit(hit);
    };
    ChainMail.prototype.GetArmorIntegrity = function () {
        return .9 * this.decoratedArmor.GetArmorIntegrity();
    };
    return ChainMail;
})();

var HeavyChainMail = (function () {
    function HeavyChainMail(decoratedArmor) {
        this.decoratedArmor = decoratedArmor;
    }
    HeavyChainMail.prototype.CalculateDamageFromHit = function (hit) {
        hit.Strength = hit.Strength * 0.7; // Reduz mais ainda
        return this.decoratedArmor.CalculateDamageFromHit(hit);
    };
    return HeavyChainMail;
})();

// Instancia o decorator com a armadura básica
var armor = new ChainMail(new BasicArmor());

// Objeto que representa o golpe
var hit = {
    Location: "head",
    Weapon: "Sock filled with pennies",
    Strength: 12
};

// Calcula o dano após passar pela armadura decorada
var damage = armor.CalculateDamageFromHit(hit);

// Mostra o resultado
console.log("Dano sofrido:", damage); // Saída esperada: 12 * 0.8 = 9.6

// Armadura duplamente decorada
var superArmor = new HeavyChainMail(new ChainMail(new BasicArmor()));
var hit = { Location: "chest", Weapon: "Sword", Strength: 20 };

console.log("Dano sofrido:", superArmor.CalculateDamageFromHit(hit));
// Saída esperada: 20 * 0.7 * 0.8 = 11.2