import { useEffect, useState } from "react";
import api from "../api/api";
import type {Pessoa} from "../types/Pessoa";

export default function Pessoas() {
    const [pessoas, setPessoas] = useState<Pessoa[]>([]);

    useEffect(() => {
        api.get<Pessoa[]>("/pessoas/listar-pessoas")
            .then(res => setPessoas(res.data))
            .catch(err => console.error(err));
    }, []);

    return (
        <div>
            <h2>Pessoas</h2>

            <ul>
                {pessoas.map(p => (
                    <li key={p.id}>
                        {p.nomeCompleto} — {p.idade} anos
                    </li>
                ))}
            </ul>
        </div>
    );
}
