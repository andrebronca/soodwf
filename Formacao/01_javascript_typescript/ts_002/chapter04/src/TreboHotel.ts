import { Room } from "./Room.js";

export class TreboHotel extends Room {
    private static instance: TreboHotel;

    private constructor(room: string, private roomRent: number) {
        super(room);
    }

    static getInstance() {
        if (!TreboHotel.instance) {
            TreboHotel.instance = new TreboHotel('Trebo', 1000);
        }
        return TreboHotel.instance;
    }

    cleanRoom(soap: string): void {
        console.log(`${this.room}'s Trebo Room cleaned with ${soap}`);
    }

}