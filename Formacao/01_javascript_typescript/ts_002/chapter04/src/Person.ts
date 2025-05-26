import { Greeting } from './IGreeting.js';

export class Person implements Greeting {

    private _name: string;

    constructor(name: string) {
        this._name = name;
    }

    public get name(): string {
        return this._name;
    }

    public set name(value: string) {
        this._name = value;
    }

    greet(sentence: string): void {
        console.log(`${sentence}, ${this.name}`);
    }


}