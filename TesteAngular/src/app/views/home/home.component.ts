import { Component, OnInit } from '@angular/core';
import { ActivatedRoute, Router } from '@angular/router';
import { RouteService } from '../../services/route.service';
import { Route } from 'src/app/models/route.model';

@Component({
  selector: 'app-route-form',
  templateUrl: './home.component.html',
  styleUrls: ['./home.component.css'],
})
export class HomeComponent implements OnInit {
  routeForm: Route = new Route();
  route: Route = { origin: '', destination: '', cost: 0, bestRoute: '' };
  isEditMode: boolean = false;
  isEditOrNew = false;
  routes: Route[] = [];

  constructor(
    private routeService: RouteService,
    private activatedRoute: ActivatedRoute,
    private router: Router
  ) {}

  ngOnInit(): void {
    const origin = this.activatedRoute.snapshot.paramMap.get('origin');
    const destination =
      this.activatedRoute.snapshot.paramMap.get('destination');
    this.loadRoutes();
  }

  loadRoutes(): void {
    this.routeService.getRoutes().subscribe((data: Route[]) => {
      this.routes = data;
    });
  }
  deleteRoute(id?: number): void {
    this.routeService.deleteRoute(id).subscribe(() => {
      this.loadRoutes();
      this.limparForm();
    });
  }

  update(id?: number): void {
    this.isEditMode = true;
    this.isEditOrNew = true;
    this.routeService.getRoute(id).subscribe((data: Route) => {
      this.route = data;
    });
  }
  create(): void {
    this.isEditMode = false;
    this.isEditOrNew = true;
  }

  saveRoute(): void {
    if (this.isEditMode) {
      this.routeService.updateRoute(this.route).subscribe(() => {
        this.loadRoutes();
        this.limparForm();
      });
    } else {
      this.routeService.addRoute(this.route).subscribe(() => {
        this.loadRoutes();
        this.limparForm();
      });
    }
  }

  limparForm() {
    this.isEditOrNew = false;
    this.route.id = 0;
    this.route.origin = '';
    this.route.destination = '';
    this.route.bestRoute = '';
  }

  cancelar() {
    this.limparForm();
  }
  getCheapestRoute(): void {
    this.routeService
      .getCheapestRoute(this.route.origin, this.route.destination)
      .subscribe((data: Route) => {
        this.route = data;
      });
  }
}
