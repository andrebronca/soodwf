import { Room } from "./Room";
export class OyoRoom extends Room {
    // private reports: string[] = [];
    constructor(room, roomRent) {
        super(room);
        this.roomRent = roomRent;
    }
    // get allReports() {
    //     return this.reports;
    // }
    // set newReport(report: string) {
    //     this.reports.push(report);
    // }
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
}
//# sourceMappingURL=OyoRoom.js.map