import { Greeting } from "./IGreeting.js";

export class Dog implements Greeting {
    nickName: string = "Doggy";

    constructor(public name: string) { }

    greet(sentence: string): void {
        console.log(`${sentence} ${this.name} (${this.nickName})`);
    }

}