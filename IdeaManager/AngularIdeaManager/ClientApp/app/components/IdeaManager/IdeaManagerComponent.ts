import { Component } from '@angular/core';
import { Http, Headers } from '@angular/http';

@Component({
    selector: "idea-manager",
    template: require('./IdeaManagerComponent.html')
})
export class IdeaManagerComponent {
    public ideas: any[] = []; 
    API_URI = "/api/IdeaService";
    constructor(private http: Http) {
        // 출력
        this.http.get(this.API_URI).subscribe(r => {
            this.ideas = r.json();
        }); 
    }    

    // 입력
    btnSave(formValue) {
        var headers = new Headers(); 
        headers.append("Content-Type", "application/json");
        this.http.post(
            this.API_URI, JSON.stringify(formValue), { headers: headers })
            .subscribe(r => {
                this.ideas.push(r.json()); 
            });
    }
}
