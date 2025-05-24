export class CreateRoom {
    public room: string;
    private family: string[] = [];
    readonly dobShikha: string = '1982-12-12';
    private readonly dobHriday: string = '2013-12-12';

    constructor(name: string) {
        this.room = `${name}s room`;
    }

    // nesse caso não precisaria da declaração no início da classe
    // constructor(public room: string){}

    addFamilyMember(member: string) {
        this.family.push(member);
    }

    showFamily() {
        console.log(this.family);
    }

    cleanRoom(soap: string) {
        console.log(`Cleaning ${this.room} with ${soap}`);
    }
}