import { Injectable } from "@angular/core";

@Injectable({
    providedIn: 'root'
})
export class LocalStorageService {

    clearLocalStorage(): void {
        window.localStorage.clear();
    }

    setItem(key: string, value: any): void {
        window.localStorage.setItem(key, JSON.stringify(value));
    }

    getItem(key: string) {
        const item = window.localStorage.getItem(key);
        return (item === null) ? null : JSON.parse(item);
    }
}