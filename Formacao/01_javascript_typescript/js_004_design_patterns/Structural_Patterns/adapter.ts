interface Ship {
    SetRudderAngleTo(angle: number);
    //SetSailConfiguration(configuration: SailConfiguration);
    SetSailAngle(sailId: number, sailAngle: number);
    getCurrentbearing(): number;
    getCurrentSpeedEstimate(): number;
    ShiftCrewWeightTo(weightToShift: number, locationId: number);
}

interface SimpleShip {
    TurneLeft();
    TurnRight();
    GoForward();
}