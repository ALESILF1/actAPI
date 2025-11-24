import { Routes } from '@angular/router';
import { HomeComponent } from './views/home/home.component';
import { AddProdutoComponent } from './views/add-produto/add-produto.component';
import { ProdutoEditComponent } from './views/produto-edit/produto-edit.component';

export const routes: Routes = [
  { path: '', component: HomeComponent },
  { path: 'Adicionar-Produto', component: AddProdutoComponent },
  { path: 'Editar-Produto/:id', component: ProdutoEditComponent },
];
