export class CreateRoom {
    constructor(name) {
        this.family = [];
        this.dobShikha = '1982-12-12';
        this.dobHriday = '2013-12-12';
        this.room = `${name}s room`;
    }
    // nesse caso não precisaria da declaração no início da classe
    // constructor(public room: string){}
    addFamilyMember(member) {
        this.family.push(member);
    }
    showFamily() {
        console.log(this.family);
    }
    cleanRoom(soap) {
        console.log(`Cleaning ${this.room} with ${soap}`);
    }
}
//# sourceMappingURL=CreateRoom.js.map