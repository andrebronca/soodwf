import { Room } from "./Room.js";
export class OyoRoom extends Room {
    constructor(room, roomRent) {
        super(room);
        this.roomRent = roomRent;
        this.reports = [];
    }
    //property - ini
    get allReports() {
        return this.reports;
    }
    set newReport(report) {
        this.reports.push(report);
    }
    //property - fim
    static createRoom(room) {
        return { room: room };
    }
    // orverride
    addFamilyMember(member) {
        if (member === 'Kapil')
            return;
        this.family.push(member);
    }
    changeRoomRent(rent) {
        this.roomRent = rent;
    }
    showRoomRent() {
        console.log(`${this.room}'s room rent is ${this.roomRent}`);
    }
    cleanRoom(soap) {
        console.log(`Cleaning ${this.room} with ${soap}.`);
    }
}
OyoRoom.currentYear = 2022;
//# sourceMappingURL=OyoRoom.js.map