import { Component, OnInit } from '@angular/core';
import { FormBuilder } from '@angular/forms';
import { Router } from '@angular/router';
import { PoBreadcrumb, PoDynamicViewField, PoMenuItem, PoNotificationService, PoTagType } from '@po-ui/ng-components';
import { GeralService } from 'src/app/services/geral/geral.service';
import { HomeService } from 'src/app/services/home/home.service';

@Component({
  selector: 'app-home',
  templateUrl: './home.component.html',
  styleUrls: ['./home.component.css']
})
export class HomeComponent implements OnInit {

  titulo: string = 'Nome do time';
  statusValue: string = 'Success';
  type: PoTagType.Danger;
  seqUsuario: number;
  seqTime: number;

  public readonly breadcrumb: PoBreadcrumb = {
    items: [{ label: 'Home', link: '/home' }, { label: 'Dashboard' }]
  };

  camposGerais: Array<PoDynamicViewField> = [
    
    { property: 'nome', divider: 'Dados Gerais', gridColumns: 4, order: 1 },
    { property: 'idade', label: 'Idade', gridColumns: 4 },
    { property: 'email',label: 'Email', gridColumns: 4 },
    { property: 'cpf', label: 'CPF', gridColumns: 4, order: 2 },
    { property: 'rg', label: 'RG', gridColumns: 4, order: 3 },
    { property: 'aniversario', label: 'Aniversário', gridColumns: 4 },
  ];

  camposEstatisticas: Array<PoDynamicViewField> = [
    
    { property: 'posicao', divider: 'Estatísticas', gridColumns: 3, order: 1 },
    { property: 'jogosJogados', label: 'Jogos', gridColumns: 3 },
    { property: 'gols',label: 'Gols', gridColumns: 3 },
    { property: 'ca',label: 'Cartões amarelos', gridColumns: 3 },
    { property: 'cv',label: 'Cartões vermelhos', gridColumns: 3 },
    { property: 'golsSofridos',label: 'Gols sofridos', gridColumns: 3 },
    { property: 'Mensalidade', tag: true, color: 'color-11', icon: 'po-icon-ok' },
  ];

 dadosJogador = {};
 dadosJogadorEstatisticas = {};
  
  constructor(private homeService: HomeService,
    private formBuilder: FormBuilder,
    private poNotification: PoNotificationService,
    private router: Router,
    private servicoGeral: GeralService) { }

  ngOnInit(): void {
    this.homeService.buscarUsuario(this.servicoGeral.seqUsuario).subscribe(dados => {
      this.seqTime = dados.items[0].seqTime;

      this.homeService.buscarTime(this.seqTime).subscribe(dadosTime => {
        this.titulo = dadosTime.items[0].nomeTime;
      }); 

      this.homeService.buscarJogador(this.servicoGeral.seqUsuario).subscribe(dadosJogador => {
        this.obterDadosGrid(dados, dadosJogador);
      });

      
    });
  }

  obterDadosGrid(dados: any, dadosJgdr: any){
    this.dadosJogador = {
      nome: dados.items[0].nomeUsuario,
      idade: '20',
      rg: dados.items[0].rg,
      email: dados.items[0].email,
      cpf: dados.items[0].cpf,
      aniversario: dados.items[0].dtaNascimento
    };

    this.dadosJogadorEstatisticas = {
      posicao: dados.items[0].nomeUsuario,
      jogosJogados: dadosJgdr.items[0].jogosJogados,
      gols: dadosJgdr.items[0].gols,
      ca: dadosJgdr.items[0].ca,
      cv: dadosJgdr.items[0].cv,
      golsSofridos: dadosJgdr.items[0].golsSofridos,
    }
  }

}
