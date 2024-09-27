export interface reservaModel{
    idReserva: number,
    idUsuario: number,
    idSala: number,
    priority: number,
    horaInicio: string,
    horaFin: string,
    state: string
}