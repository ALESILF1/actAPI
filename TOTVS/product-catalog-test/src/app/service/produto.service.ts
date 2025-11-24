import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { Observable } from 'rxjs';
import { Produto, CreateProduct, UpdateProduct } from '../model/produto.model';

@Injectable({
  providedIn: 'root',
})
export class ProdutoService {
  private apiUrl = 'https://localhost:5001/api/produto';

  constructor(private http: HttpClient) {}

  getProduto(): Observable<Produto[]> {
    return this.http.get<Produto[]>(this.apiUrl);
  }

  addProduto(produto: CreateProduct): Observable<Produto> {
    return this.http.post<Produto>(this.apiUrl, produto);
  }

  getProdutoById(id: string): Observable<Produto> {
    return this.http.get<Produto>(`${this.apiUrl}/${id}`);
  }

  updateProduto(
    editingIndex: string,
    updatedProduto: UpdateProduct
  ): Observable<Produto> {
    return this.http.put<Produto>(
      `${this.apiUrl}/${editingIndex}`,
      updatedProduto
    );
  }

  deleteProduto(index: string): Observable<void> {
    return this.http.delete<void>(`${this.apiUrl}/${index}`);
  }
}
