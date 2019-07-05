using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;
using Positivo.AtividadesComplementares.Positivo.AtividadesComplementares.Domain.Entity;

namespace Positivo.AtividadesComplementares.Positivo.AtividadesComplementares.Infrastructure
{
    public partial class PositivoDbContext : DbContext
    {
        public PositivoDbContext()
        {
        }

        public PositivoDbContext(DbContextOptions<PositivoDbContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Aluno> Aluno { get; set; }
        public virtual DbSet<Atividade> Atividade { get; set; }
        public virtual DbSet<Curso> Curso { get; set; }
        public virtual DbSet<Execucao> Execucao { get; set; }
        public virtual DbSet<Servico> Servico { get; set; }
        public virtual DbSet<Solicitacao> Solicitacao { get; set; }
        public virtual DbSet<SolicitacaoAtividadeLcs> SolicitacaoAtividadeLcs { get; set; }
        public virtual DbSet<TipoCurso> TipoCurso { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.HasAnnotation("ProductVersion", "2.2.4-servicing-10062");

            modelBuilder.Entity<Aluno>(entity =>
            {
                entity.ToTable("aluno");

                entity.HasIndex(e => e.CodAluno)
                    .HasName("UK_ALUNO_01")
                    .IsUnique();

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.CodAluno).HasColumnName("cod_aluno");

                entity.Property(e => e.NmAluno)
                    .IsRequired()
                    .HasColumnName("nm_aluno")
                    .HasMaxLength(200)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<Atividade>(entity =>
            {
                entity.ToTable("atividade");

                entity.HasIndex(e => e.CodAtividade)
                    .HasName("UK_atividade_01")
                    .IsUnique();

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.CodAtividade).HasColumnName("cod_atividade");

                entity.Property(e => e.DsAtividade)
                    .IsRequired()
                    .HasColumnName("ds_atividade")
                    .HasMaxLength(200)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<Curso>(entity =>
            {
                entity.ToTable("curso");

                entity.HasIndex(e => e.CodCurso)
                    .HasName("UK_curso_01")
                    .IsUnique();

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.CodCurso).HasColumnName("cod_curso");

                entity.Property(e => e.NmCurso)
                    .HasColumnName("nm_curso")
                    .HasMaxLength(200)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<Execucao>(entity =>
            {
                entity.ToTable("execucao");

                entity.HasIndex(e => e.DhExecucao)
                    .HasName("UK_execucao_01")
                    .IsUnique();

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.DhExecucao)
                    .HasColumnName("dh_execucao")
                    .HasDefaultValueSql("(sysdatetime())");

                entity.Property(e => e.FlStatus)
                    .IsRequired()
                    .HasColumnName("fl_status")
                    .HasMaxLength(1)
                    .IsUnicode(false);

                entity.Property(e => e.NumTentativas).HasColumnName("num_tentativas");
            });

            modelBuilder.Entity<Servico>(entity =>
            {
                entity.ToTable("servico");

                entity.HasIndex(e => e.CodServico)
                    .HasName("UK_servico_01")
                    .IsUnique();

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.CodServico)
                    .IsRequired()
                    .HasColumnName("cod_servico")
                    .HasMaxLength(20)
                    .IsUnicode(false);

                entity.Property(e => e.NmServico)
                    .IsRequired()
                    .HasColumnName("nm_servico")
                    .HasMaxLength(100)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<Solicitacao>(entity =>
            {
                entity.ToTable("solicitacao");

                entity.HasIndex(e => e.CodSolicitacao)
                    .HasName("UK_solicitacao_01")
                    .IsUnique();

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.CodSolicitacao).HasColumnName("cod_solicitacao");

                entity.Property(e => e.DhFim).HasColumnName("dh_fim");

                entity.Property(e => e.DhInicio).HasColumnName("dh_inicio");

                entity.Property(e => e.DhUpdate).HasColumnName("dh_update");

                entity.Property(e => e.DsAtividade)
                    .HasColumnName("ds_atividade")
                    .HasMaxLength(200)
                    .IsUnicode(false);

                entity.Property(e => e.DsMotivo)
                    .HasColumnName("ds_motivo")
                    .HasMaxLength(2000)
                    .IsUnicode(false);

                entity.Property(e => e.DsMotivoRpa)
                    .HasColumnName("ds_motivo_rpa")
                    .HasMaxLength(2000)
                    .IsUnicode(false);

                entity.Property(e => e.DsUrlArquivo)
                    .HasColumnName("ds_url_arquivo")
                    .HasMaxLength(200)
                    .IsUnicode(false);

                entity.Property(e => e.DtSolicitacao).HasColumnName("dt_solicitacao");

                entity.Property(e => e.FlAvaliacaoRpa)
                    .IsRequired()
                    .HasColumnName("fl_avaliacao_rpa")
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .HasDefaultValueSql("('P')");

                entity.Property(e => e.FlCertificadoPositivo).HasColumnName("fl_certificado_positivo");

                entity.Property(e => e.FlStatus)
                    .IsRequired()
                    .HasColumnName("fl_status")
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .HasDefaultValueSql("('P')");

                entity.Property(e => e.FlValidacaoAluno).HasColumnName("fl_validacao_aluno");

                entity.Property(e => e.FlValidacaoAtividade).HasColumnName("fl_validacao_atividade");

                entity.Property(e => e.FlValidacaoData).HasColumnName("fl_validacao_data");

                entity.Property(e => e.FlValidacaoHoras).HasColumnName("fl_validacao_horas");

                entity.Property(e => e.HorasDeferidas)
                    .HasColumnName("horas_deferidas")
                    .HasColumnType("numeric(5, 2)");

                entity.Property(e => e.HorasSolicitadas)
                    .HasColumnName("horas_solicitadas")
                    .HasColumnType("numeric(5, 2)");

                entity.Property(e => e.IdAluno).HasColumnName("id_aluno");

                entity.Property(e => e.IdCurso).HasColumnName("id_curso");

                entity.Property(e => e.IdServico).HasColumnName("id_servico");

                entity.Property(e => e.IdTipoCurso).HasColumnName("id_tipo_curso");

                entity.Property(e => e.NmUsuario)
                    .IsRequired()
                    .HasColumnName("nm_usuario")
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.HasOne(d => d.IdAlunoNavigation)
                    .WithMany(p => p.Solicitacao)
                    .HasForeignKey(d => d.IdAluno)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__solicitac__id_al__48CFD27E");

                entity.HasOne(d => d.IdCursoNavigation)
                    .WithMany(p => p.Solicitacao)
                    .HasForeignKey(d => d.IdCurso)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__solicitac__id_cu__49C3F6B7");

                entity.HasOne(d => d.IdServicoNavigation)
                    .WithMany(p => p.Solicitacao)
                    .HasForeignKey(d => d.IdServico)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__solicitac__id_se__4AB81AF0");

                entity.HasOne(d => d.IdTipoCursoNavigation)
                    .WithMany(p => p.Solicitacao)
                    .HasForeignKey(d => d.IdTipoCurso)
                    .HasConstraintName("FK__solicitac__id_ti__4BAC3F29");
            });

            modelBuilder.Entity<SolicitacaoAtividadeLcs>(entity =>
            {
                entity.ToTable("solicitacao_atividade_lcs");

                entity.HasIndex(e => new { e.IdAtividade, e.IdSolicitacao })
                    .HasName("UK_solicitacao_atividade_lcs_01")
                    .IsUnique();

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.AnoAtividade).HasColumnName("ano_atividade");

                entity.Property(e => e.CargaHoraria)
                    .IsRequired()
                    .HasColumnName("carga_horaria")
                    .HasMaxLength(6)
                    .IsUnicode(false);

                entity.Property(e => e.IdAtividade).HasColumnName("id_atividade");

                entity.Property(e => e.IdSolicitacao).HasColumnName("id_solicitacao");

                entity.HasOne(d => d.IdAtividadeNavigation)
                    .WithMany(p => p.SolicitacaoAtividadeLcs)
                    .HasForeignKey(d => d.IdAtividade)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_solicitacao_atividade_lcs_01");

                entity.HasOne(d => d.IdSolicitacaoNavigation)
                    .WithMany(p => p.SolicitacaoAtividadeLcs)
                    .HasForeignKey(d => d.IdSolicitacao)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_solicitacao_atividade_lcs_02");
            });

            modelBuilder.Entity<TipoCurso>(entity =>
            {
                entity.ToTable("tipo_curso");

                entity.HasIndex(e => e.NmTipoCurso)
                    .HasName("UK_tipo_curso_01")
                    .IsUnique();

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.NmTipoCurso)
                    .IsRequired()
                    .HasColumnName("nm_tipo_curso")
                    .HasMaxLength(100)
                    .IsUnicode(false);
            });
        }
    }
}
