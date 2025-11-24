import { Component, OnInit } from '@angular/core';
import { HeaderComponent } from '../../components/header/header.component';
import { FormsModule } from '@angular/forms';
import { CommonModule } from '@angular/common';
import { Produto, UpdateProduct } from '../../model/produto.model';
import { ProdutoService } from '../../service/produto.service';
import { ActivatedRoute, GuardsCheckEnd, Router } from '@angular/router';
import { ToastrService } from 'ngx-toastr';

@Component({
  selector: 'app-produto-edit',
  standalone: true,
  imports: [HeaderComponent, FormsModule, CommonModule],
  templateUrl: './produto-edit.component.html',
  styleUrl: './produto-edit.component.css',
})
export class ProdutoEditComponent implements OnInit {
  produto: Produto[] = [];
  editProduto: UpdateProduct = {
    nome: '',
    descricao: '',
    categoria: '',
    preco: 0,
    estoque: 0,
  };
  produtoId: string = '';
  loading: boolean = false;

  constructor(
    private produtoService: ProdutoService,
    private route: ActivatedRoute,
    private router: Router,
    private toastr: ToastrService
  ) {}

  ngOnInit(): void {
    this.route.params.subscribe((params) => {
      this.produtoId = params['id'];
      this.loadProduto(this.produtoId);
    });
  }

  loadProduto(id: string): void {
    this.produtoService.getProdutoById(id).subscribe({
      next: (products) => {
        this.editProduto = products;
        this.loading = false;
      },
      error: (error) => {
        this.loading = false;
        this.toastr.success('Error loading products:');
      },
    });
  }

  updateProduto(): void {
    this.produtoService
      .updateProduto(this.produtoId, this.editProduto)
      .subscribe({
        next: (products) => {
          this.loading = false;
          this.toastr.success('Produto atualizado com sucesso');
          this.router.navigate(['/']).then((navigated) => {
            if (!navigated) {
              this.toastr.error(
                'Não foi possivel atualziar o produto, tente novamente mais tarde'
              );
            }
          });
        },
        error: (error) => {
          this.loading = false;
          this.router.navigate(['/']).then((navigated) => {
            if (!navigated) {
              this.toastr.error(
                'Não foi possivel atualziar o produto, tente novamente mais tarde'
              );
            }
          });
        },
      });
  }
}
