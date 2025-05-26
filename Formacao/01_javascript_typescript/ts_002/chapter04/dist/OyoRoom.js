import { Room } from "./Room.js";
export class OyoRoom extends Room {
    constructor(room, roomRent) {
        super(room);
        this.roomRent = roomRent;
        this.reports = [];
    }
    get allReports() {
        return this.reports;
    }
    set newReport(report) {
        this.reports.push(report);
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
}
//# sourceMappingURL=OyoRoom.js.map