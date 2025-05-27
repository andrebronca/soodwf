import { Room } from "./Room.js";
export class TreboHotel extends Room {
    constructor(room, roomRent) {
        super(room);
        this.roomRent = roomRent;
    }
    static getInstance() {
        if (!TreboHotel.instance) {
            TreboHotel.instance = new TreboHotel('Trebo', 1000);
        }
        return TreboHotel.instance;
    }
    cleanRoom(soap) {
        console.log(`${this.room}'s Trebo Room cleaned with ${soap}`);
    }
}
//# sourceMappingURL=TreboHotel.js.map