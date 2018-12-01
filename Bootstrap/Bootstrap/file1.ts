
import { Component } from 'angular/core';

@Component({
    selector: 'my-component',
    template: '안녕하세요, 제 이름은 {{name}}입니다.'
})
export class ExampleComponent {
    constructor() {
        this.name = 'Sam';
    }
}


import { Pipe, PipeTransform } from 'angular/core';

@Pipe({
    name: 'mypipe'
})
export class MyPipePipe implements PipeTransform {
    transform(value: any, args: any[]): any {
    }
}

return this.http.get('url')
    .map((response: Response) => response.json());


import { Injectable } from 'angular/core';

@Injectable()
export class HelloWorldService {

}
