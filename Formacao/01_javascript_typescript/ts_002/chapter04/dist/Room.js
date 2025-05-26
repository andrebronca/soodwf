export class Room {
    constructor(room) {
        this.room = room;
        this.family = [];
        this.dobShikha = '1982-12-12';
        this.dobHriday = '2013-12-12';
    }
    addFamilyMember(member) {
        this.family.push(member);
    }
    showFamily() {
        console.log(this.family);
    }
    cleanRoom(soap) {
        console.log(`Cleaning ${this.room} with ${soap}.`);
    }
}
//# sourceMappingURL=Room.js.map