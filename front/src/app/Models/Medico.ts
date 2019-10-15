import { Usuario } from './Usuario';

export class Medico {
    user: Usuario;
    titulation: Titulacao;
    name: string;
    crm: string;
}

export enum Titulacao{
    residente =0,
    docente = 1 ,
    efetivo = 2,
}