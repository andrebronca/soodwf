interface Naming {
    readonly name: string;
    //opcional '?'
    nickName?: string;
}

export interface Greeting extends Naming {
    greet(sentence: string): void;
}