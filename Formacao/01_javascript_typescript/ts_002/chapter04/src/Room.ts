export class Room {
    protected family: string[] = [];
    readonly dobShikha: string = '1982-12-12';
    private readonly dobHriday: string = '2013-12-12';

    constructor(public room: string) {

    }

    addFamilyMember(member: string) {
        this.family.push(member);
    }

    showFamily() {
        console.log(this.family);
    }

    cleanRoom(soap: string) {
        console.log(`Cleaning ${this.room} with ${soap}.`);
    }
}