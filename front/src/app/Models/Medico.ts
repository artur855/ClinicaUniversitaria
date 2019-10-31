import { Usuario } from './Usuario';

export class Medico {
    user: Usuario;
    titulation: Titulacao;
    crm: string;
    name: string;
    email:string;
}

export enum Titulacao{
    residente =0,
    docente = 1 ,
    efetivo = 2,
}

