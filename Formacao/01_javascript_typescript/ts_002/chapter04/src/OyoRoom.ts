import { Room } from "./Room";

export class OyoRoom extends Room {
    // private reports: string[] = [];

    constructor(room: string, private roomRent: number) {
        super(room);
    }

    // get allReports() {
    //     return this.reports;
    // }

    // set newReport(report: string) {
    //     this.reports.push(report);
    // }

    // orverride
    addFamilyMember(member: string): void {
        if (member === 'Kapil') return
        this.family.push(member);
    }

    changeRoomRent(rent: number) {
        this.roomRent = rent;
    }

    showRoomRent() {
        console.log(`${this.room}'s room rent is ${this.roomRent}`);
    }
}