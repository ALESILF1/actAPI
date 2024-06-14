// src/app/services/route.service.ts
import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { Observable } from 'rxjs';
import { Route } from '../models/route.model';

@Injectable({
  providedIn: 'root',
})
export class RouteService {
  private apiUrl = 'https://localhost:5001/api/Rota';

  constructor(private http: HttpClient) {}

  getRoutes(): Observable<Route[]> {
    return this.http.get<Route[]>(this.apiUrl);
  }

  getRoute(id?: number): Observable<Route> {
    return this.http.get<Route>(`${this.apiUrl}/${id}`);
  }

  addRoute(route: Route): Observable<Route> {
    return this.http.post<Route>(this.apiUrl, route);
  }

  updateRoute(route: Route): Observable<Route> {
    return this.http.put<Route>(this.apiUrl, route);
  }

  deleteRoute(id?: number): Observable<void> {
    return this.http.delete<void>(`${this.apiUrl}/${id}`);
  }

  getCheapestRoute(origin: string, destination: string): Observable<Route> {
    var ret = this.http.get<Route>(
      `${this.apiUrl}/getCalculoRota/${origin}/${destination}`
    );
    return ret;
  }
}
