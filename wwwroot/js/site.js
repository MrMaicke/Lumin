class Perfil {
    constructor(id, usuarioId, nome, bio, avatar) {
        this.id = id;
        this.usuarioId = usuarioId;
        this.nome = nome;
        this.bio = bio;
        this.avatar = avatar; // pode ser um path ou avatar padrão
    }
}

class PerfilController {

    // Mostra o perfil do usuário logado
    visualizarPerfil(req, res) {
        const usuarioId = req.session.usuarioId;
        const perfil = PerfilService.buscarPorUsuario(usuarioId);
        res.render("perfil/visualizar", { perfil });
    }

    // Formulário de edição
    editarPerfilForm(req, res) {
        const usuarioId = req.session.usuarioId;
        const perfil = PerfilService.buscarPorUsuario(usuarioId);
        res.render("perfil/editar", { perfil });
    }

    // Salvar alterações
    atualizarPerfil(req, res) {
        const usuarioId = req.session.usuarioId;
        const nome = req.body.nome;
        const bio = req.body.bio;

        PerfilService.atualizar(usuarioId, { nome, bio });

        res.redirect("/perfil");
    }

    // Visualizar perfil de outra pessoa
    visualizarPublico(req, res) {
        const perfilId = req.params.id;
        const perfil = PerfilService.buscarPorId(perfilId);
        res.render("perfil/publico", { perfil });
    }
}

class PerfilService {

    static buscarPorUsuario(usuarioId) {
        return db.query("SELECT * FROM perfis WHERE usuario_id = ?", [usuarioId]);
    }

    static buscarPorId(id) {
        return db.query("SELECT * FROM perfis WHERE id = ?", [id]);
    }

    static atualizar(usuarioId, dados) {
        return db.query(
            "UPDATE perfis SET nome = ?, bio = ? WHERE usuario_id = ?",
            [dados.nome, dados.bio, usuarioId]
        );
    }
}
