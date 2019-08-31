import { Usuario } from './Usuario';

export class Patient {
    id: number;
    user: Usuario;
    sex: string;
    color: string;
    birthdate: Date;
}

export enum PatientColor {
    Branco = 0,
    Negro = 1,
    Pardo = 2,
    Indigena = 3,
    'Nao Especificado' = 4
}

export enum PatientSex {
    Masculino = 'M',
    Feminino = 'F'
}