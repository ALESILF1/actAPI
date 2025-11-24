import { Component, OnInit } from '@angular/core';
import { HeaderComponent } from '../../components/header/header.component';
import { Produto } from '../../model/produto.model';
import { ProdutoService } from '../../service/produto.service';
import { FormsModule } from '@angular/forms';
import { CommonModule } from '@angular/common';
import { RouterModule } from '@angular/router';
import { ToastrService } from 'ngx-toastr';

@Component({
  selector: 'app-home',
  standalone: true,
  imports: [HeaderComponent, FormsModule, CommonModule, RouterModule],
  templateUrl: './home.component.html',
  styleUrl: './home.component.css',
})
export class HomeComponent implements OnInit {
  produtos: Produto[] = [];
  novoProduto: Produto = {
    id: '',
    nome: '',
    descricao: '',
    preco: 0,
    estoque: 0,
    categoria: '',
    dataCriacao: '',
    dataAtualizacao: '',
    IsActive: false,
  };
  editingIndex: number | null = null;
  loading: boolean = false;

  constructor(private produtoService: ProdutoService, private toastr: ToastrService) {}

  ngOnInit(): void {
    this.loadProduto();
  }

  loadProduto(): void {
    this.loading = true;

    this.produtoService.getProduto().subscribe({
      next: (products) => {
        this.produtos = products;
        this.loading = false;
      },
      error: (error) => {
        this.loading = false;
        this.toastr.error('Error loading products:');
      },
    });
  }

  editProduto(index: string): void {
    this.produtoService.getProdutoById(index).subscribe({
      next: (products) => {
        this.loadProduto();
        this.loading = false;
      },
      error: (error) => {
        this.loading = false;
        this.toastr.error('Error loading products:',error);
      },
    });
  }

  deleteProduto(index: string): void {

    this.produtoService.deleteProduto(index).subscribe({
      next: (products) => {
        this.loadProduto();
        this.loading = false;
      },
      error: (error) => {
        this.loading = false;
        this.toastr.error('Error loading products:',error);
      },
    });

    this.toastr.success('Produto Excluido com Sucesso');
  }

  confirmDelete(productId: string, productName: string): void {
    const toast = this.toastr.info(
      `Deseja realmente excluir o produto "${productName}"?<br><br>
       <button class="btn btn-danger btn-sm me-2" onclick="document.getElementById('confirmDelete').click()">Sim, Excluir</button>
       <button class="btn btn-secondary btn-sm" onclick="document.getElementById('cancelDelete').click()">Cancelar</button>`,
      'Confirmar Exclusão',
      {
        enableHtml: true,
        disableTimeOut: true,
        closeButton: true,
        tapToDismiss: false
      }
    );

    // Criar elementos hidden para capturar os cliques
    this.createHiddenButtons(toast, productId);
  }

  private createHiddenButtons(toast: any, productId: string): void {
    // Aguardar o toast ser renderizado
    setTimeout(() => {
      const toastElement = document.querySelector('.toast') as HTMLElement;

      if (toastElement) {
        // Botão Confirmar
        const confirmButton = document.createElement('button');
        confirmButton.id = 'confirmDelete';
        confirmButton.style.display = 'none';
        confirmButton.addEventListener('click', () => {
          this.deleteProduto(productId);
          this.toastr.clear(toast.toastId);
        });

        // Botão Cancelar
        const cancelButton = document.createElement('button');
        cancelButton.id = 'cancelDelete';
        cancelButton.style.display = 'none';
        cancelButton.addEventListener('click', () => {
          this.toastr.clear(toast.toastId);
          this.toastr.info('Exclusão cancelada', 'Cancelado');
        });

        toastElement.appendChild(confirmButton);
        toastElement.appendChild(cancelButton);
      }
    }, 100);
  }
}
