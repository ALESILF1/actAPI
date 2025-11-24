import { Component, OnInit } from '@angular/core';
import { HeaderComponent } from '../../components/header/header.component';
import { FormsModule } from '@angular/forms';
import { CommonModule } from '@angular/common';
import { Produto, CreateProduct } from '../../model/produto.model';
import { ProdutoService } from '../../service/produto.service';
import { Router } from '@angular/router';
import { ToastrService } from 'ngx-toastr';

@Component({
  selector: 'app-add-produto',
  standalone: true,
  imports: [HeaderComponent, FormsModule, CommonModule],
  templateUrl: './add-produto.component.html',
  styleUrl: './add-produto.component.css',
})
export class AddProdutoComponent implements OnInit {
  produtos: Produto[] = [];
  NovoProduto: CreateProduct = {
    nome: '',
    descricao: '',
    categoria: '',
    preco: 0,
    estoque: 0,
  };
  editingIndex: string | null = null;
  loading: boolean = false;
  constructor(
    private produtoService: ProdutoService,
    private router: Router,
    private toastr: ToastrService
  ) {}

  ngOnInit(): void {
    this.NovoProduto = {
      nome: '',
      descricao: '',
      categoria: '',
      preco: 0,
      estoque: 0,
    };
  }

  addProduto(): void {
    this.produtoService.addProduto(this.NovoProduto).subscribe({
      next: (products) => {
        this.loading = false;
         this.toastr.success('Produto Criado com Sucesso');
        this.router.navigate(['/']).then((navigated) => {
          if (!navigated) {
             this.toastr.error(
               'Não foi possivel criar um novo produto, tente novamente mais tarde'
             ,'');
          }
        });
      },
      error: (error) => {
        this.loading = false;
        this.router.navigate(['/']).then((navigated) => {
          if (!navigated) {
             this.toastr.error(
               'Não foi possivel criar um novo produto, tente novamente mais tarde'
             ,error);
          }
        });
      },
    });
  }
}
