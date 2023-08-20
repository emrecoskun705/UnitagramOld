using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace Unitagram.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class AddUniversitySeedData : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "University",
                columns: new[] { "Id", "Domain", "Inserted", "IsActive", "IsDeleted", "LastUpdated", "Name", "Province" },
                values: new object[,]
                {
                    { 1, "adanabtu.edu.tr", new DateTime(2023, 8, 20, 15, 37, 55, 823, DateTimeKind.Local).AddTicks(705), true, false, new DateTime(2023, 8, 20, 15, 37, 55, 823, DateTimeKind.Local).AddTicks(718), "ADANA BİLİM VE TEKNOLOJİ ÜNİVERSİTESİ", "ADANA" },
                    { 2, "cu.edu.tr", new DateTime(2023, 8, 20, 15, 37, 55, 823, DateTimeKind.Local).AddTicks(744), true, false, new DateTime(2023, 8, 20, 15, 37, 55, 823, DateTimeKind.Local).AddTicks(744), "ÇUKUROVA ÜNİVERSİTESİ", "ADANA" },
                    { 3, "adiyaman.edu.tr", new DateTime(2023, 8, 20, 15, 37, 55, 823, DateTimeKind.Local).AddTicks(750), true, false, new DateTime(2023, 8, 20, 15, 37, 55, 823, DateTimeKind.Local).AddTicks(750), "ADIYAMAN ÜNİVERSİTESİ", "ADIYAMAN" },
                    { 4, "aku.edu.tr", new DateTime(2023, 8, 20, 15, 37, 55, 823, DateTimeKind.Local).AddTicks(755), true, false, new DateTime(2023, 8, 20, 15, 37, 55, 823, DateTimeKind.Local).AddTicks(755), "AFYON KOCATEPE ÜNİVERSİTESİ", "AFYONKARAHİSAR" },
                    { 5, "", new DateTime(2023, 8, 20, 15, 37, 55, 823, DateTimeKind.Local).AddTicks(759), true, false, new DateTime(2023, 8, 20, 15, 37, 55, 823, DateTimeKind.Local).AddTicks(760), "AFYONKARAHİSAR SAĞLIK BİLİMLERİ ÜNİVERSİTESİ", "AFYONKARAHİSAR" },
                    { 6, "agri.edu.tr", new DateTime(2023, 8, 20, 15, 37, 55, 823, DateTimeKind.Local).AddTicks(766), true, false, new DateTime(2023, 8, 20, 15, 37, 55, 823, DateTimeKind.Local).AddTicks(766), "AĞRI İBRAHİM ÇEÇEN ÜNİVERSİTESİ", "AĞRI" },
                    { 7, "amasya.edu.tr", new DateTime(2023, 8, 20, 15, 37, 55, 823, DateTimeKind.Local).AddTicks(770), true, false, new DateTime(2023, 8, 20, 15, 37, 55, 823, DateTimeKind.Local).AddTicks(771), "AMASYA ÜNİVERSİTESİ", "AMASYA" },
                    { 8, "", new DateTime(2023, 8, 20, 15, 37, 55, 823, DateTimeKind.Local).AddTicks(775), true, false, new DateTime(2023, 8, 20, 15, 37, 55, 823, DateTimeKind.Local).AddTicks(775), "ANKA TEKNOLOJİ ÜNİVERSİTESİ", "ANKARA" },
                    { 9, "", new DateTime(2023, 8, 20, 15, 37, 55, 823, DateTimeKind.Local).AddTicks(780), true, false, new DateTime(2023, 8, 20, 15, 37, 55, 823, DateTimeKind.Local).AddTicks(780), "ANKARA HACI BAYRAM VELİ ÜNİVERSİTESİ", "ANKARA" },
                    { 10, "", new DateTime(2023, 8, 20, 15, 37, 55, 823, DateTimeKind.Local).AddTicks(815), true, false, new DateTime(2023, 8, 20, 15, 37, 55, 823, DateTimeKind.Local).AddTicks(815), "ANKARA MEDİPOL ÜNİVERSİTESİ", "ANKARA" },
                    { 11, "", new DateTime(2023, 8, 20, 15, 37, 55, 823, DateTimeKind.Local).AddTicks(820), true, false, new DateTime(2023, 8, 20, 15, 37, 55, 823, DateTimeKind.Local).AddTicks(820), "ANKARA MÜZİK VE GÜZEL SANATLAR ÜNİVERSİTESİ", "ANKARA" },
                    { 12, "asbu.edu.tr", new DateTime(2023, 8, 20, 15, 37, 55, 823, DateTimeKind.Local).AddTicks(824), true, false, new DateTime(2023, 8, 20, 15, 37, 55, 823, DateTimeKind.Local).AddTicks(825), "ANKARA SOSYAL BİLİMLER ÜNİVERSİTESİ", "ANKARA" },
                    { 13, "ankara.edu.tr", new DateTime(2023, 8, 20, 15, 37, 55, 823, DateTimeKind.Local).AddTicks(829), true, false, new DateTime(2023, 8, 20, 15, 37, 55, 823, DateTimeKind.Local).AddTicks(830), "ANKARA ÜNİVERSİTESİ", "ANKARA" },
                    { 14, "ybu.edu.tr", new DateTime(2023, 8, 20, 15, 37, 55, 823, DateTimeKind.Local).AddTicks(834), true, false, new DateTime(2023, 8, 20, 15, 37, 55, 823, DateTimeKind.Local).AddTicks(834), "ANKARA YILDIRIM BEYAZIT ÜNİVERSİTESİ", "ANKARA" },
                    { 15, "atilim.edu.tr", new DateTime(2023, 8, 20, 15, 37, 55, 823, DateTimeKind.Local).AddTicks(838), true, false, new DateTime(2023, 8, 20, 15, 37, 55, 823, DateTimeKind.Local).AddTicks(839), "ATILIM ÜNİVERSİTESİ", "ANKARA" },
                    { 16, "baskent.edu.tr", new DateTime(2023, 8, 20, 15, 37, 55, 823, DateTimeKind.Local).AddTicks(843), true, false, new DateTime(2023, 8, 20, 15, 37, 55, 823, DateTimeKind.Local).AddTicks(843), "BAŞKENT ÜNİVERSİTESİ", "ANKARA" },
                    { 17, "cankaya.edu.tr", new DateTime(2023, 8, 20, 15, 37, 55, 823, DateTimeKind.Local).AddTicks(847), true, false, new DateTime(2023, 8, 20, 15, 37, 55, 823, DateTimeKind.Local).AddTicks(847), "ÇANKAYA ÜNİVERSİTESİ", "ANKARA" },
                    { 18, "gazi.edu.tr", new DateTime(2023, 8, 20, 15, 37, 55, 823, DateTimeKind.Local).AddTicks(852), true, false, new DateTime(2023, 8, 20, 15, 37, 55, 823, DateTimeKind.Local).AddTicks(852), "GAZİ ÜNİVERSİTESİ", "ANKARA" },
                    { 19, "hacettepe.edu.tr", new DateTime(2023, 8, 20, 15, 37, 55, 823, DateTimeKind.Local).AddTicks(856), true, false, new DateTime(2023, 8, 20, 15, 37, 55, 823, DateTimeKind.Local).AddTicks(857), "HACETTEPE ÜNİVERSİTESİ", "ANKARA" },
                    { 20, "bilkent.edu.tr", new DateTime(2023, 8, 20, 15, 37, 55, 823, DateTimeKind.Local).AddTicks(861), true, false, new DateTime(2023, 8, 20, 15, 37, 55, 823, DateTimeKind.Local).AddTicks(861), "İHSAN DOĞRAMACI BİLKENT ÜNİVERSİTESİ", "ANKARA" },
                    { 21, "", new DateTime(2023, 8, 20, 15, 37, 55, 823, DateTimeKind.Local).AddTicks(865), true, false, new DateTime(2023, 8, 20, 15, 37, 55, 823, DateTimeKind.Local).AddTicks(865), "LOKMAN HEKİM ÜNİVERSİTESİ", "ANKARA" },
                    { 22, "metu.edu.tr", new DateTime(2023, 8, 20, 15, 37, 55, 823, DateTimeKind.Local).AddTicks(869), true, false, new DateTime(2023, 8, 20, 15, 37, 55, 823, DateTimeKind.Local).AddTicks(870), "ORTA DOĞU TEKNİK ÜNİVERSİTESİ", "ANKARA" },
                    { 23, "", new DateTime(2023, 8, 20, 15, 37, 55, 823, DateTimeKind.Local).AddTicks(874), true, false, new DateTime(2023, 8, 20, 15, 37, 55, 823, DateTimeKind.Local).AddTicks(874), "OSTİM TEKNİK ÜNİVERSİTESİ", "ANKARA" },
                    { 24, "tedu.edu.tr", new DateTime(2023, 8, 20, 15, 37, 55, 823, DateTimeKind.Local).AddTicks(878), true, false, new DateTime(2023, 8, 20, 15, 37, 55, 823, DateTimeKind.Local).AddTicks(879), "TED ÜNİVERSİTESİ", "ANKARA" },
                    { 25, "etu.edu.tr", new DateTime(2023, 8, 20, 15, 37, 55, 823, DateTimeKind.Local).AddTicks(883), true, false, new DateTime(2023, 8, 20, 15, 37, 55, 823, DateTimeKind.Local).AddTicks(883), "TOBB EKONOMİ VE TEKNOLOJİ ÜNİVERSİTESİ", "ANKARA" },
                    { 26, "thk.edu.tr", new DateTime(2023, 8, 20, 15, 37, 55, 823, DateTimeKind.Local).AddTicks(888), true, false, new DateTime(2023, 8, 20, 15, 37, 55, 823, DateTimeKind.Local).AddTicks(888), "TÜRK HAVA KURUMU ÜNİVERSİTESİ", "ANKARA" },
                    { 27, "ufuk.edu.tr", new DateTime(2023, 8, 20, 15, 37, 55, 823, DateTimeKind.Local).AddTicks(892), true, false, new DateTime(2023, 8, 20, 15, 37, 55, 823, DateTimeKind.Local).AddTicks(892), "UFUK ÜNİVERSİTESİ", "ANKARA" },
                    { 28, "yiu.edu.tr", new DateTime(2023, 8, 20, 15, 37, 55, 823, DateTimeKind.Local).AddTicks(896), true, false, new DateTime(2023, 8, 20, 15, 37, 55, 823, DateTimeKind.Local).AddTicks(897), "YÜKSEK İHTİSAS ÜNİVERSİTESİ", "ANKARA" },
                    { 29, "akdeniz.edu.tr", new DateTime(2023, 8, 20, 15, 37, 55, 823, DateTimeKind.Local).AddTicks(901), true, false, new DateTime(2023, 8, 20, 15, 37, 55, 823, DateTimeKind.Local).AddTicks(901), "AKDENİZ ÜNİVERSİTESİ", "ANTALYA" },
                    { 30, "alanya.edu.tr", new DateTime(2023, 8, 20, 15, 37, 55, 823, DateTimeKind.Local).AddTicks(906), true, false, new DateTime(2023, 8, 20, 15, 37, 55, 823, DateTimeKind.Local).AddTicks(906), "ALANYA ALAADDİN KEYKUBAT ÜNİVERSİTESİ", "ANTALYA" },
                    { 31, "ahep.edu.tr", new DateTime(2023, 8, 20, 15, 37, 55, 823, DateTimeKind.Local).AddTicks(910), true, false, new DateTime(2023, 8, 20, 15, 37, 55, 823, DateTimeKind.Local).AddTicks(910), "ALANYA HAMDULLAH EMİN PAŞA ÜNİVERSİTESİ", "ANTALYA" },
                    { 32, "akev.edu.tr", new DateTime(2023, 8, 20, 15, 37, 55, 823, DateTimeKind.Local).AddTicks(914), true, false, new DateTime(2023, 8, 20, 15, 37, 55, 823, DateTimeKind.Local).AddTicks(915), "ANTALYA AKEV ÜNİVERSİTESİ", "ANTALYA" },
                    { 33, "antalya.edu.tr", new DateTime(2023, 8, 20, 15, 37, 55, 823, DateTimeKind.Local).AddTicks(919), true, false, new DateTime(2023, 8, 20, 15, 37, 55, 823, DateTimeKind.Local).AddTicks(919), "ANTALYA BİLİM ÜNİVERSİTESİ", "ANTALYA" },
                    { 34, "artvin.edu.tr", new DateTime(2023, 8, 20, 15, 37, 55, 823, DateTimeKind.Local).AddTicks(944), true, false, new DateTime(2023, 8, 20, 15, 37, 55, 823, DateTimeKind.Local).AddTicks(944), "ARTVİN ÇORUH ÜNİVERSİTESİ", "ARTVİN" },
                    { 35, "adu.edu.tr", new DateTime(2023, 8, 20, 15, 37, 55, 823, DateTimeKind.Local).AddTicks(949), true, false, new DateTime(2023, 8, 20, 15, 37, 55, 823, DateTimeKind.Local).AddTicks(949), "AYDIN ADNAN MENDERES ÜNİVERSİTESİ", "AYDIN" },
                    { 36, "balikesir.edu.tr", new DateTime(2023, 8, 20, 15, 37, 55, 823, DateTimeKind.Local).AddTicks(954), true, false, new DateTime(2023, 8, 20, 15, 37, 55, 823, DateTimeKind.Local).AddTicks(954), "BALIKESİR ÜNİVERSİTESİ", "BALIKESİR" },
                    { 37, "bandirma.edu.tr", new DateTime(2023, 8, 20, 15, 37, 55, 823, DateTimeKind.Local).AddTicks(958), true, false, new DateTime(2023, 8, 20, 15, 37, 55, 823, DateTimeKind.Local).AddTicks(959), "BANDIRMA ONYEDİ EYLÜL ÜNİVERSİTESİ", "BALIKESİR" },
                    { 38, "bilecik.edu.tr", new DateTime(2023, 8, 20, 15, 37, 55, 823, DateTimeKind.Local).AddTicks(963), true, false, new DateTime(2023, 8, 20, 15, 37, 55, 823, DateTimeKind.Local).AddTicks(963), "BİLECİK ŞEYH EDEBALİ ÜNİVERSİTESİ", "BİLECİK" },
                    { 39, "bingol.edu.tr", new DateTime(2023, 8, 20, 15, 37, 55, 823, DateTimeKind.Local).AddTicks(968), true, false, new DateTime(2023, 8, 20, 15, 37, 55, 823, DateTimeKind.Local).AddTicks(968), "BİNGÖL ÜNİVERSİTESİ", "BİNGÖL" },
                    { 40, "beu.edu.tr", new DateTime(2023, 8, 20, 15, 37, 55, 823, DateTimeKind.Local).AddTicks(972), true, false, new DateTime(2023, 8, 20, 15, 37, 55, 823, DateTimeKind.Local).AddTicks(973), "BİTLİS EREN ÜNİVERSİTESİ", "BİTLİS" },
                    { 41, "ibu.edu.tr", new DateTime(2023, 8, 20, 15, 37, 55, 823, DateTimeKind.Local).AddTicks(977), true, false, new DateTime(2023, 8, 20, 15, 37, 55, 823, DateTimeKind.Local).AddTicks(977), "BOLU ABANT İZZET BAYSAL ÜNİVERSİTESİ", "BOLU" },
                    { 42, "mehmetakif.edu.t r", new DateTime(2023, 8, 20, 15, 37, 55, 823, DateTimeKind.Local).AddTicks(981), true, false, new DateTime(2023, 8, 20, 15, 37, 55, 823, DateTimeKind.Local).AddTicks(981), "BURDUR MEHMET AKİF ERSOY ÜNİVERSİTESİ", "BURDUR" },
                    { 43, "btu.edu.tr", new DateTime(2023, 8, 20, 15, 37, 55, 823, DateTimeKind.Local).AddTicks(985), true, false, new DateTime(2023, 8, 20, 15, 37, 55, 823, DateTimeKind.Local).AddTicks(986), "BURSA TEKNİK ÜNİVERSİTESİ", "BURSA" },
                    { 44, "uludag.edu.tr", new DateTime(2023, 8, 20, 15, 37, 55, 823, DateTimeKind.Local).AddTicks(990), true, false, new DateTime(2023, 8, 20, 15, 37, 55, 823, DateTimeKind.Local).AddTicks(990), "BURSA ULUDAĞ ÜNİVERSİTESİ", "BURSA" },
                    { 45, "faruksarac.edu.tr", new DateTime(2023, 8, 20, 15, 37, 55, 823, DateTimeKind.Local).AddTicks(994), true, false, new DateTime(2023, 8, 20, 15, 37, 55, 823, DateTimeKind.Local).AddTicks(995), "FARUK SARAÇ TASARIM MESLEK YÜKSEKOKULU", "BURSA" },
                    { 46, "comu.edu.tr", new DateTime(2023, 8, 20, 15, 37, 55, 823, DateTimeKind.Local).AddTicks(999), true, false, new DateTime(2023, 8, 20, 15, 37, 55, 823, DateTimeKind.Local).AddTicks(999), "ÇANAKKALE ONSEKİZ MART ÜNİVERSİTESİ", "ÇANAKKALE" },
                    { 47, "karatekin.edu.tr", new DateTime(2023, 8, 20, 15, 37, 55, 823, DateTimeKind.Local).AddTicks(1003), true, false, new DateTime(2023, 8, 20, 15, 37, 55, 823, DateTimeKind.Local).AddTicks(1003), "ÇANKIRI KARATEKİN ÜNİVERSİTESİ", "ÇANKIRI" },
                    { 48, "hitit.edu.tr", new DateTime(2023, 8, 20, 15, 37, 55, 823, DateTimeKind.Local).AddTicks(1007), true, false, new DateTime(2023, 8, 20, 15, 37, 55, 823, DateTimeKind.Local).AddTicks(1008), "HİTİT ÜNİVERSİTESİ", "ÇORUM" },
                    { 49, "pau.edu.tr", new DateTime(2023, 8, 20, 15, 37, 55, 823, DateTimeKind.Local).AddTicks(1012), true, false, new DateTime(2023, 8, 20, 15, 37, 55, 823, DateTimeKind.Local).AddTicks(1012), "PAMUKKALE ÜNİVERSİTESİ", "DENİZLİ" },
                    { 50, "dicle.edu.tr", new DateTime(2023, 8, 20, 15, 37, 55, 823, DateTimeKind.Local).AddTicks(1016), true, false, new DateTime(2023, 8, 20, 15, 37, 55, 823, DateTimeKind.Local).AddTicks(1016), "DİCLE ÜNİVERSİTESİ", "DİYARBAKIR" },
                    { 51, "trakya.edu.tr", new DateTime(2023, 8, 20, 15, 37, 55, 823, DateTimeKind.Local).AddTicks(1020), true, false, new DateTime(2023, 8, 20, 15, 37, 55, 823, DateTimeKind.Local).AddTicks(1021), "TRAKYA ÜNİVERSİTESİ", "EDİRNE" },
                    { 52, "firat.edu.tr", new DateTime(2023, 8, 20, 15, 37, 55, 823, DateTimeKind.Local).AddTicks(1025), true, false, new DateTime(2023, 8, 20, 15, 37, 55, 823, DateTimeKind.Local).AddTicks(1025), "FIRAT ÜNİVERSİTESİ", "ELAZIĞ" },
                    { 53, "erzincan.edu.tr", new DateTime(2023, 8, 20, 15, 37, 55, 823, DateTimeKind.Local).AddTicks(1029), true, false, new DateTime(2023, 8, 20, 15, 37, 55, 823, DateTimeKind.Local).AddTicks(1029), "ERZİNCAN BİNALİ YILDIRIM ÜNİVERSİTESİ", "ERZİNCAN" },
                    { 54, "atauni.edu.tr", new DateTime(2023, 8, 20, 15, 37, 55, 823, DateTimeKind.Local).AddTicks(1033), true, false, new DateTime(2023, 8, 20, 15, 37, 55, 823, DateTimeKind.Local).AddTicks(1034), "ATATÜRK ÜNİVERSİTESİ", "ERZURUM" },
                    { 55, "erzurum.edu.tr", new DateTime(2023, 8, 20, 15, 37, 55, 823, DateTimeKind.Local).AddTicks(1038), true, false, new DateTime(2023, 8, 20, 15, 37, 55, 823, DateTimeKind.Local).AddTicks(1038), "ERZURUM TEKNİK ÜNİVERSİTESİ", "ERZURUM" },
                    { 56, "anadolu.edu.tr", new DateTime(2023, 8, 20, 15, 37, 55, 823, DateTimeKind.Local).AddTicks(1042), true, false, new DateTime(2023, 8, 20, 15, 37, 55, 823, DateTimeKind.Local).AddTicks(1042), "ANADOLU ÜNİVERSİTESİ", "ESKİŞEHİR" },
                    { 57, "ogu.edu.tr", new DateTime(2023, 8, 20, 15, 37, 55, 823, DateTimeKind.Local).AddTicks(1046), true, false, new DateTime(2023, 8, 20, 15, 37, 55, 823, DateTimeKind.Local).AddTicks(1047), "ESKİŞEHİR OSMANGAZİ ÜNİVERSİTESİ", "ESKİŞEHİR" },
                    { 58, "", new DateTime(2023, 8, 20, 15, 37, 55, 823, DateTimeKind.Local).AddTicks(1051), true, false, new DateTime(2023, 8, 20, 15, 37, 55, 823, DateTimeKind.Local).AddTicks(1051), "ESKİŞEHİR TEKNİK ÜNİVERSİTESİ", "ESKİŞEHİR" },
                    { 59, "", new DateTime(2023, 8, 20, 15, 37, 55, 823, DateTimeKind.Local).AddTicks(1075), true, false, new DateTime(2023, 8, 20, 15, 37, 55, 823, DateTimeKind.Local).AddTicks(1075), "GAZİANTEP BİLİM VE TEKNOLOJİ ÜNİVERSİTESİ", "GAZİANTEP" },
                    { 60, "gantep.edu.tr", new DateTime(2023, 8, 20, 15, 37, 55, 823, DateTimeKind.Local).AddTicks(1081), true, false, new DateTime(2023, 8, 20, 15, 37, 55, 823, DateTimeKind.Local).AddTicks(1081), "GAZİANTEP ÜNİVERSİTESİ", "GAZİANTEP" },
                    { 61, "hku.edu.tr", new DateTime(2023, 8, 20, 15, 37, 55, 823, DateTimeKind.Local).AddTicks(1085), true, false, new DateTime(2023, 8, 20, 15, 37, 55, 823, DateTimeKind.Local).AddTicks(1086), "HASAN KALYONCU ÜNİVERSİTESİ", "GAZİANTEP" },
                    { 62, "sanko.edu.tr", new DateTime(2023, 8, 20, 15, 37, 55, 823, DateTimeKind.Local).AddTicks(1090), true, false, new DateTime(2023, 8, 20, 15, 37, 55, 823, DateTimeKind.Local).AddTicks(1091), "SANKO ÜNİVERSİTESİ", "GAZİANTEP" },
                    { 63, "giresun.edu.tr", new DateTime(2023, 8, 20, 15, 37, 55, 823, DateTimeKind.Local).AddTicks(1095), true, false, new DateTime(2023, 8, 20, 15, 37, 55, 823, DateTimeKind.Local).AddTicks(1095), "GİRESUN ÜNİVERSİTESİ", "GİRESUN" },
                    { 64, "gumushane.edu.tr", new DateTime(2023, 8, 20, 15, 37, 55, 823, DateTimeKind.Local).AddTicks(1099), true, false, new DateTime(2023, 8, 20, 15, 37, 55, 823, DateTimeKind.Local).AddTicks(1099), "GÜMÜŞHANE ÜNİVERSİTESİ", "GÜMÜŞHANE" },
                    { 65, "hakkari.edu.tr", new DateTime(2023, 8, 20, 15, 37, 55, 823, DateTimeKind.Local).AddTicks(1103), true, false, new DateTime(2023, 8, 20, 15, 37, 55, 823, DateTimeKind.Local).AddTicks(1104), "HAKKARİ ÜNİVERSİTESİ", "HAKKARİ" },
                    { 66, "mku.edu.tr", new DateTime(2023, 8, 20, 15, 37, 55, 823, DateTimeKind.Local).AddTicks(1109), true, false, new DateTime(2023, 8, 20, 15, 37, 55, 823, DateTimeKind.Local).AddTicks(1109), "HATAY MUSTAFA KEMAL ÜNİVERSİTESİ", "HATAY" },
                    { 67, "iste.edu.tr", new DateTime(2023, 8, 20, 15, 37, 55, 823, DateTimeKind.Local).AddTicks(1113), true, false, new DateTime(2023, 8, 20, 15, 37, 55, 823, DateTimeKind.Local).AddTicks(1114), "İSKENDERUN TEKNİK ÜNİVERSİTESİ", "HATAY" },
                    { 68, "", new DateTime(2023, 8, 20, 15, 37, 55, 823, DateTimeKind.Local).AddTicks(1118), true, false, new DateTime(2023, 8, 20, 15, 37, 55, 823, DateTimeKind.Local).AddTicks(1118), "ISPARTA UYGULAMALI BİLİMLER ÜNİVERSİTESİ", "ISPARTA" },
                    { 69, "sdu.edu.tr", new DateTime(2023, 8, 20, 15, 37, 55, 823, DateTimeKind.Local).AddTicks(1122), true, false, new DateTime(2023, 8, 20, 15, 37, 55, 823, DateTimeKind.Local).AddTicks(1122), "SÜLEYMAN DEMİREL ÜNİVERSİTESİ", "ISPARTA" },
                    { 70, "cag.edu.tr", new DateTime(2023, 8, 20, 15, 37, 55, 823, DateTimeKind.Local).AddTicks(1126), true, false, new DateTime(2023, 8, 20, 15, 37, 55, 823, DateTimeKind.Local).AddTicks(1127), "ÇAĞ ÜNİVERSİTESİ", "MERSİN" },
                    { 71, "mersin.edu.tr", new DateTime(2023, 8, 20, 15, 37, 55, 823, DateTimeKind.Local).AddTicks(1131), true, false, new DateTime(2023, 8, 20, 15, 37, 55, 823, DateTimeKind.Local).AddTicks(1131), "MERSİN ÜNİVERSİTESİ", "MERSİN" },
                    { 72, "", new DateTime(2023, 8, 20, 15, 37, 55, 823, DateTimeKind.Local).AddTicks(1135), true, false, new DateTime(2023, 8, 20, 15, 37, 55, 823, DateTimeKind.Local).AddTicks(1135), "TARSUS ÜNİVERSİTESİ", "MERSİN" },
                    { 73, "toros.edu.tr", new DateTime(2023, 8, 20, 15, 37, 55, 823, DateTimeKind.Local).AddTicks(1139), true, false, new DateTime(2023, 8, 20, 15, 37, 55, 823, DateTimeKind.Local).AddTicks(1140), "TOROS ÜNİVERSİTESİ", "MERSİN" },
                    { 74, "acibadem.edu.tr", new DateTime(2023, 8, 20, 15, 37, 55, 823, DateTimeKind.Local).AddTicks(1144), true, false, new DateTime(2023, 8, 20, 15, 37, 55, 823, DateTimeKind.Local).AddTicks(1144), "ACIBADEM MEHMET ALİ AYDINLAR ÜNİVERSİTESİ", "İSTANBUL" },
                    { 75, "altinbas.edu.tr", new DateTime(2023, 8, 20, 15, 37, 55, 823, DateTimeKind.Local).AddTicks(1148), true, false, new DateTime(2023, 8, 20, 15, 37, 55, 823, DateTimeKind.Local).AddTicks(1148), "ALTINBAŞ ÜNİVERSİTESİ", "İSTANBUL" },
                    { 76, "adiguzel.edu.tr", new DateTime(2023, 8, 20, 15, 37, 55, 823, DateTimeKind.Local).AddTicks(1153), true, false, new DateTime(2023, 8, 20, 15, 37, 55, 823, DateTimeKind.Local).AddTicks(1153), "ATAŞEHİR ADIGÜZEL MESLEK YÜKSEKOKULU", "İSTANBUL" },
                    { 77, "avrupa.edu.tr", new DateTime(2023, 8, 20, 15, 37, 55, 823, DateTimeKind.Local).AddTicks(1157), true, false, new DateTime(2023, 8, 20, 15, 37, 55, 823, DateTimeKind.Local).AddTicks(1157), "AVRUPA MESLEK YÜKSEKOKULU", "İSTANBUL" },
                    { 78, "bahcesehir.edu.tr", new DateTime(2023, 8, 20, 15, 37, 55, 823, DateTimeKind.Local).AddTicks(1161), true, false, new DateTime(2023, 8, 20, 15, 37, 55, 823, DateTimeKind.Local).AddTicks(1161), "BAHÇEŞEHİR ÜNİVERSİTESİ", "İSTANBUL" },
                    { 79, "beykent.edu.tr", new DateTime(2023, 8, 20, 15, 37, 55, 823, DateTimeKind.Local).AddTicks(1165), true, false, new DateTime(2023, 8, 20, 15, 37, 55, 823, DateTimeKind.Local).AddTicks(1166), "BEYKENT ÜNİVERSİTESİ", "İSTANBUL" },
                    { 80, "beykoz.edu.tr", new DateTime(2023, 8, 20, 15, 37, 55, 823, DateTimeKind.Local).AddTicks(1170), true, false, new DateTime(2023, 8, 20, 15, 37, 55, 823, DateTimeKind.Local).AddTicks(1171), "BEYKOZ ÜNİVERSİTESİ", "İSTANBUL" },
                    { 81, "bezmialem.edu.tr", new DateTime(2023, 8, 20, 15, 37, 55, 823, DateTimeKind.Local).AddTicks(1175), true, false, new DateTime(2023, 8, 20, 15, 37, 55, 823, DateTimeKind.Local).AddTicks(1175), "BEZM-İ ÂLEM VAKIF ÜNİVERSİTESİ", "İSTANBUL" },
                    { 82, "biruni.edu.tr", new DateTime(2023, 8, 20, 15, 37, 55, 823, DateTimeKind.Local).AddTicks(1202), true, false, new DateTime(2023, 8, 20, 15, 37, 55, 823, DateTimeKind.Local).AddTicks(1202), "BİRUNİ ÜNİVERSİTESİ", "İSTANBUL" },
                    { 83, "boun.edu.tr", new DateTime(2023, 8, 20, 15, 37, 55, 823, DateTimeKind.Local).AddTicks(1207), true, false, new DateTime(2023, 8, 20, 15, 37, 55, 823, DateTimeKind.Local).AddTicks(1207), "BOĞAZİÇİ ÜNİVERSİTESİ", "İSTANBUL" },
                    { 84, "dogus.edu.tr", new DateTime(2023, 8, 20, 15, 37, 55, 823, DateTimeKind.Local).AddTicks(1212), true, false, new DateTime(2023, 8, 20, 15, 37, 55, 823, DateTimeKind.Local).AddTicks(1213), "DOĞUŞ ÜNİVERSİTESİ", "İSTANBUL" },
                    { 85, "fsm.edu.tr", new DateTime(2023, 8, 20, 15, 37, 55, 823, DateTimeKind.Local).AddTicks(1217), true, false, new DateTime(2023, 8, 20, 15, 37, 55, 823, DateTimeKind.Local).AddTicks(1217), "FATİH SULTAN MEHMET VAKIF ÜNİVERSİTESİ", "İSTANBUL" },
                    { 86, "", new DateTime(2023, 8, 20, 15, 37, 55, 823, DateTimeKind.Local).AddTicks(1222), true, false, new DateTime(2023, 8, 20, 15, 37, 55, 823, DateTimeKind.Local).AddTicks(1222), "FENERBAHÇE ÜNİVERSİTESİ", "İSTANBUL" },
                    { 87, "gsu.edu.tr", new DateTime(2023, 8, 20, 15, 37, 55, 823, DateTimeKind.Local).AddTicks(1226), true, false, new DateTime(2023, 8, 20, 15, 37, 55, 823, DateTimeKind.Local).AddTicks(1226), "GALATASARAY ÜNİVERSİTESİ", "İSTANBUL" },
                    { 88, "halic.edu.tr", new DateTime(2023, 8, 20, 15, 37, 55, 823, DateTimeKind.Local).AddTicks(1230), true, false, new DateTime(2023, 8, 20, 15, 37, 55, 823, DateTimeKind.Local).AddTicks(1231), "HALİÇ ÜNİVERSİTESİ", "İSTANBUL" },
                    { 89, "isikun.edu.tr", new DateTime(2023, 8, 20, 15, 37, 55, 823, DateTimeKind.Local).AddTicks(1235), true, false, new DateTime(2023, 8, 20, 15, 37, 55, 823, DateTimeKind.Local).AddTicks(1235), "IŞIK ÜNİVERSİTESİ", "İSTANBUL" },
                    { 90, "ibnhaldun.edu.tr", new DateTime(2023, 8, 20, 15, 37, 55, 823, DateTimeKind.Local).AddTicks(1240), true, false, new DateTime(2023, 8, 20, 15, 37, 55, 823, DateTimeKind.Local).AddTicks(1240), "İBN HALDUN ÜNİVERSİTESİ", "İSTANBUL" },
                    { 91, "arel.edu.tr", new DateTime(2023, 8, 20, 15, 37, 55, 823, DateTimeKind.Local).AddTicks(1244), true, false, new DateTime(2023, 8, 20, 15, 37, 55, 823, DateTimeKind.Local).AddTicks(1244), "İSTANBUL AREL ÜNİVERSİTESİ", "İSTANBUL" },
                    { 92, "", new DateTime(2023, 8, 20, 15, 37, 55, 823, DateTimeKind.Local).AddTicks(1248), true, false, new DateTime(2023, 8, 20, 15, 37, 55, 823, DateTimeKind.Local).AddTicks(1249), "İSTANBUL ATLAS ÜNİVERSİTESİ", "İSTANBUL" },
                    { 93, "aydin.edu.tr", new DateTime(2023, 8, 20, 15, 37, 55, 823, DateTimeKind.Local).AddTicks(1253), true, false, new DateTime(2023, 8, 20, 15, 37, 55, 823, DateTimeKind.Local).AddTicks(1253), "İSTANBUL AYDIN ÜNİVERSİTESİ", "İSTANBUL" },
                    { 94, "ayvansaray.edu.tr", new DateTime(2023, 8, 20, 15, 37, 55, 823, DateTimeKind.Local).AddTicks(1257), true, false, new DateTime(2023, 8, 20, 15, 37, 55, 823, DateTimeKind.Local).AddTicks(1257), "İSTANBUL AYVANSARAY ÜNİVERSİTESİ", "İSTANBUL" },
                    { 95, "bilgi.edu.tr", new DateTime(2023, 8, 20, 15, 37, 55, 823, DateTimeKind.Local).AddTicks(1261), true, false, new DateTime(2023, 8, 20, 15, 37, 55, 823, DateTimeKind.Local).AddTicks(1262), "İSTANBUL BİLGİ ÜNİVERSİTESİ", "İSTANBUL" },
                    { 96, "istanbulbilim.edu.tr", new DateTime(2023, 8, 20, 15, 37, 55, 823, DateTimeKind.Local).AddTicks(1266), true, false, new DateTime(2023, 8, 20, 15, 37, 55, 823, DateTimeKind.Local).AddTicks(1266), "İSTANBUL BİLİM ÜNİVERSİTESİ", "İSTANBUL" },
                    { 97, "esenyurt.edu.tr", new DateTime(2023, 8, 20, 15, 37, 55, 823, DateTimeKind.Local).AddTicks(1270), true, false, new DateTime(2023, 8, 20, 15, 37, 55, 823, DateTimeKind.Local).AddTicks(1271), "İSTANBUL ESENYURT ÜNİVERSİTESİ", "İSTANBUL" },
                    { 98, "gedik.edu.tr", new DateTime(2023, 8, 20, 15, 37, 55, 823, DateTimeKind.Local).AddTicks(1275), true, false, new DateTime(2023, 8, 20, 15, 37, 55, 823, DateTimeKind.Local).AddTicks(1275), "İSTANBUL GEDİK ÜNİVERSİTESİ", "İSTANBUL" },
                    { 99, "gelisim.edu.tr", new DateTime(2023, 8, 20, 15, 37, 55, 823, DateTimeKind.Local).AddTicks(1280), true, false, new DateTime(2023, 8, 20, 15, 37, 55, 823, DateTimeKind.Local).AddTicks(1280), "İSTANBUL GELİŞİM ÜNİVERSİTESİ", "İSTANBUL" },
                    { 100, "kent.edu.tr", new DateTime(2023, 8, 20, 15, 37, 55, 823, DateTimeKind.Local).AddTicks(1284), true, false, new DateTime(2023, 8, 20, 15, 37, 55, 823, DateTimeKind.Local).AddTicks(1284), "İSTANBUL KENT ÜNİVERSİTESİ", "İSTANBUL" },
                    { 101, "iku.edu.tr", new DateTime(2023, 8, 20, 15, 37, 55, 823, DateTimeKind.Local).AddTicks(1288), true, false, new DateTime(2023, 8, 20, 15, 37, 55, 823, DateTimeKind.Local).AddTicks(1288), "İSTANBUL KÜLTÜR ÜNİVERSİTESİ", "İSTANBUL" },
                    { 102, "medeniyet.edu.tr", new DateTime(2023, 8, 20, 15, 37, 55, 823, DateTimeKind.Local).AddTicks(1292), true, false, new DateTime(2023, 8, 20, 15, 37, 55, 823, DateTimeKind.Local).AddTicks(1293), "İSTANBUL MEDENİYET ÜNİVERSİTESİ", "İSTANBUL" },
                    { 103, "medipol.edu.tr", new DateTime(2023, 8, 20, 15, 37, 55, 823, DateTimeKind.Local).AddTicks(1297), true, false, new DateTime(2023, 8, 20, 15, 37, 55, 823, DateTimeKind.Local).AddTicks(1297), "İSTANBUL MEDİPOL ÜNİVERSİTESİ", "İSTANBUL" },
                    { 104, "okan.edu.tr", new DateTime(2023, 8, 20, 15, 37, 55, 823, DateTimeKind.Local).AddTicks(1301), true, false, new DateTime(2023, 8, 20, 15, 37, 55, 823, DateTimeKind.Local).AddTicks(1301), "İSTANBUL OKAN ÜNİVERSİTESİ", "İSTANBUL" },
                    { 105, "rumeli.edu.tr", new DateTime(2023, 8, 20, 15, 37, 55, 823, DateTimeKind.Local).AddTicks(1306), true, false, new DateTime(2023, 8, 20, 15, 37, 55, 823, DateTimeKind.Local).AddTicks(1306), "İSTANBUL RUMELİ ÜNİVERSİTESİ", "İSTANBUL" },
                    { 106, "izu.edu.tr", new DateTime(2023, 8, 20, 15, 37, 55, 823, DateTimeKind.Local).AddTicks(1310), true, false, new DateTime(2023, 8, 20, 15, 37, 55, 823, DateTimeKind.Local).AddTicks(1310), "İSTANBUL SABAHATTİN ZAİM ÜNİVERSİTESİ", "İSTANBUL" },
                    { 107, "sehir.edu.tr - rektorluk", new DateTime(2023, 8, 20, 15, 37, 55, 823, DateTimeKind.Local).AddTicks(1315), true, false, new DateTime(2023, 8, 20, 15, 37, 55, 823, DateTimeKind.Local).AddTicks(1315), "İSTANBUL ŞEHİR ÜNİVERSİTESİ", "İSTANBUL" },
                    { 108, "sisli.edu.tr", new DateTime(2023, 8, 20, 15, 37, 55, 823, DateTimeKind.Local).AddTicks(1341), true, false, new DateTime(2023, 8, 20, 15, 37, 55, 823, DateTimeKind.Local).AddTicks(1342), "İSTANBUL ŞİŞLİ MESLEK YÜKSEKOKULU", "İSTANBUL" },
                    { 109, "itu.edu.tr", new DateTime(2023, 8, 20, 15, 37, 55, 823, DateTimeKind.Local).AddTicks(1347), true, false, new DateTime(2023, 8, 20, 15, 37, 55, 823, DateTimeKind.Local).AddTicks(1347), "İSTANBUL TEKNİK ÜNİVERSİTESİ", "İSTANBUL" },
                    { 110, "ticaret.edu.tr", new DateTime(2023, 8, 20, 15, 37, 55, 823, DateTimeKind.Local).AddTicks(1351), true, false, new DateTime(2023, 8, 20, 15, 37, 55, 823, DateTimeKind.Local).AddTicks(1351), "İSTANBUL TİCARET ÜNİVERSİTESİ", "İSTANBUL" },
                    { 111, "istanbul.edu.tr", new DateTime(2023, 8, 20, 15, 37, 55, 823, DateTimeKind.Local).AddTicks(1356), true, false, new DateTime(2023, 8, 20, 15, 37, 55, 823, DateTimeKind.Local).AddTicks(1356), "İSTANBUL ÜNİVERSİTESİ", "İSTANBUL" },
                    { 112, "", new DateTime(2023, 8, 20, 15, 37, 55, 823, DateTimeKind.Local).AddTicks(1360), true, false, new DateTime(2023, 8, 20, 15, 37, 55, 823, DateTimeKind.Local).AddTicks(1361), "İSTANBUL ÜNİVERSİTESİ - CERRAHPAŞA", "İSTANBUL" },
                    { 113, "yeniyuzyil.edu.tr", new DateTime(2023, 8, 20, 15, 37, 55, 823, DateTimeKind.Local).AddTicks(1365), true, false, new DateTime(2023, 8, 20, 15, 37, 55, 823, DateTimeKind.Local).AddTicks(1365), "İSTANBUL YENİ YÜZYIL ÜNİVERSİTESİ", "İSTANBUL" },
                    { 114, "29mayis.edu.tr", new DateTime(2023, 8, 20, 15, 37, 55, 823, DateTimeKind.Local).AddTicks(1369), true, false, new DateTime(2023, 8, 20, 15, 37, 55, 823, DateTimeKind.Local).AddTicks(1370), "İSTANBUL 29 MAYIS ÜNİVERSİTESİ", "İSTANBUL" },
                    { 115, "istinye.edu.tr", new DateTime(2023, 8, 20, 15, 37, 55, 823, DateTimeKind.Local).AddTicks(1374), true, false, new DateTime(2023, 8, 20, 15, 37, 55, 823, DateTimeKind.Local).AddTicks(1374), "İSTİNYE ÜNİVERSİTESİ", "İSTANBUL" },
                    { 116, "kavram.edu.tr", new DateTime(2023, 8, 20, 15, 37, 55, 823, DateTimeKind.Local).AddTicks(1378), true, false, new DateTime(2023, 8, 20, 15, 37, 55, 823, DateTimeKind.Local).AddTicks(1378), "İZMİR KAVRAM MESLEK YÜKSEKOKULU", "İSTANBUL" },
                    { 117, "khas.edu.tr", new DateTime(2023, 8, 20, 15, 37, 55, 823, DateTimeKind.Local).AddTicks(1382), true, false, new DateTime(2023, 8, 20, 15, 37, 55, 823, DateTimeKind.Local).AddTicks(1383), "KADİR HAS ÜNİVERSİTESİ", "İSTANBUL" },
                    { 118, "ku.edu.tr", new DateTime(2023, 8, 20, 15, 37, 55, 823, DateTimeKind.Local).AddTicks(1387), true, false, new DateTime(2023, 8, 20, 15, 37, 55, 823, DateTimeKind.Local).AddTicks(1387), "KOÇ ÜNİVERSİTESİ", "İSTANBUL" },
                    { 119, "maltepe.edu.tr", new DateTime(2023, 8, 20, 15, 37, 55, 823, DateTimeKind.Local).AddTicks(1391), true, false, new DateTime(2023, 8, 20, 15, 37, 55, 823, DateTimeKind.Local).AddTicks(1391), "MALTEPE ÜNİVERSİTESİ", "İSTANBUL" },
                    { 120, "", new DateTime(2023, 8, 20, 15, 37, 55, 823, DateTimeKind.Local).AddTicks(1395), true, false, new DateTime(2023, 8, 20, 15, 37, 55, 823, DateTimeKind.Local).AddTicks(1396), "MARMARA ÜNİVERSİTESİ", "İSTANBUL" },
                    { 121, "mef.edu.tr", new DateTime(2023, 8, 20, 15, 37, 55, 823, DateTimeKind.Local).AddTicks(1399), true, false, new DateTime(2023, 8, 20, 15, 37, 55, 823, DateTimeKind.Local).AddTicks(1400), "MEF ÜNİVERSİTESİ", "İSTANBUL" },
                    { 122, "msgsu.edu.tr", new DateTime(2023, 8, 20, 15, 37, 55, 823, DateTimeKind.Local).AddTicks(1404), true, false, new DateTime(2023, 8, 20, 15, 37, 55, 823, DateTimeKind.Local).AddTicks(1404), "MİMAR SİNAN GÜZEL SANATLAR ÜNİVERSİTESİ", "İSTANBUL" },
                    { 123, "nisantasi. edu.", new DateTime(2023, 8, 20, 15, 37, 55, 823, DateTimeKind.Local).AddTicks(1408), true, false, new DateTime(2023, 8, 20, 15, 37, 55, 823, DateTimeKind.Local).AddTicks(1408), "NİŞANTAŞI ÜNİVERSİTESİ", "İSTANBUL" },
                    { 124, "ozyegin.edu.tr", new DateTime(2023, 8, 20, 15, 37, 55, 823, DateTimeKind.Local).AddTicks(1412), true, false, new DateTime(2023, 8, 20, 15, 37, 55, 823, DateTimeKind.Local).AddTicks(1413), "ÖZYEĞİN ÜNİVERSİTESİ", "İSTANBUL" },
                    { 125, "pirireis.edu.tr", new DateTime(2023, 8, 20, 15, 37, 55, 823, DateTimeKind.Local).AddTicks(1417), true, false, new DateTime(2023, 8, 20, 15, 37, 55, 823, DateTimeKind.Local).AddTicks(1417), "PİRİ REİS ÜNİVERSİTESİ", "İSTANBUL" },
                    { 126, "sabanciuniv.edu", new DateTime(2023, 8, 20, 15, 37, 55, 823, DateTimeKind.Local).AddTicks(1421), true, false, new DateTime(2023, 8, 20, 15, 37, 55, 823, DateTimeKind.Local).AddTicks(1421), "SABANCI ÜNİVERSİTESİ", "İSTANBUL" },
                    { 127, "sbu.edu.tr", new DateTime(2023, 8, 20, 15, 37, 55, 823, DateTimeKind.Local).AddTicks(1425), true, false, new DateTime(2023, 8, 20, 15, 37, 55, 823, DateTimeKind.Local).AddTicks(1426), "SAĞLIK BİLİMLERİ ÜNİVERSİTESİ", "İSTANBUL" },
                    { 128, "", new DateTime(2023, 8, 20, 15, 37, 55, 823, DateTimeKind.Local).AddTicks(1430), true, false, new DateTime(2023, 8, 20, 15, 37, 55, 823, DateTimeKind.Local).AddTicks(1430), "SEMERKAND BİLİM VE MEDENİYET ÜNİVERSİTESİ", "İSTANBUL" },
                    { 129, "tau.edu.tr", new DateTime(2023, 8, 20, 15, 37, 55, 823, DateTimeKind.Local).AddTicks(1434), true, false, new DateTime(2023, 8, 20, 15, 37, 55, 823, DateTimeKind.Local).AddTicks(1434), "TÜRK-ALMAN ÜNİVERSİTESİ", "İSTANBUL" },
                    { 130, "", new DateTime(2023, 8, 20, 15, 37, 55, 823, DateTimeKind.Local).AddTicks(1459), true, false, new DateTime(2023, 8, 20, 15, 37, 55, 823, DateTimeKind.Local).AddTicks(1459), "TÜRKİYE ULUSLARARASI İSLAM, BİLİM VE TEKNOLOJİ ÜNİVERSİTESİ", "İSTANBUL" },
                    { 131, "", new DateTime(2023, 8, 20, 15, 37, 55, 823, DateTimeKind.Local).AddTicks(1464), true, false, new DateTime(2023, 8, 20, 15, 37, 55, 823, DateTimeKind.Local).AddTicks(1464), "TÜRK-JAPON BİLİM VE TEKNOLOJİ ÜNİVERSİTESİ", "İSTANBUL" },
                    { 132, "uskudar.edu.tr", new DateTime(2023, 8, 20, 15, 37, 55, 823, DateTimeKind.Local).AddTicks(1469), true, false, new DateTime(2023, 8, 20, 15, 37, 55, 823, DateTimeKind.Local).AddTicks(1469), "ÜSKÜDAR ÜNİVERSİTESİ", "İSTANBUL" },
                    { 133, "yeditepe.edu.tr", new DateTime(2023, 8, 20, 15, 37, 55, 823, DateTimeKind.Local).AddTicks(1474), true, false, new DateTime(2023, 8, 20, 15, 37, 55, 823, DateTimeKind.Local).AddTicks(1474), "YEDİTEPE ÜNİVERSİTESİ", "İSTANBUL" },
                    { 134, "yildiz.edu.tr", new DateTime(2023, 8, 20, 15, 37, 55, 823, DateTimeKind.Local).AddTicks(1478), true, false, new DateTime(2023, 8, 20, 15, 37, 55, 823, DateTimeKind.Local).AddTicks(1478), "YILDIZ TEKNİK ÜNİVERSİTESİ", "İSTANBUL" },
                    { 135, "deu.edu.tr", new DateTime(2023, 8, 20, 15, 37, 55, 823, DateTimeKind.Local).AddTicks(1483), true, false, new DateTime(2023, 8, 20, 15, 37, 55, 823, DateTimeKind.Local).AddTicks(1483), "DOKUZ EYLÜL ÜNİVERSİTESİ", "İZMİR" },
                    { 136, "ege.edu.tr", new DateTime(2023, 8, 20, 15, 37, 55, 823, DateTimeKind.Local).AddTicks(1487), true, false, new DateTime(2023, 8, 20, 15, 37, 55, 823, DateTimeKind.Local).AddTicks(1488), "EGE ÜNİVERSİTESİ", "İZMİR" },
                    { 137, "bakircay.edu.tr", new DateTime(2023, 8, 20, 15, 37, 55, 823, DateTimeKind.Local).AddTicks(1493), true, false, new DateTime(2023, 8, 20, 15, 37, 55, 823, DateTimeKind.Local).AddTicks(1493), "İZMİR BAKIRÇAY ÜNİVERSİTESİ", "İZMİR" },
                    { 138, "idu.edu.tr", new DateTime(2023, 8, 20, 15, 37, 55, 823, DateTimeKind.Local).AddTicks(1497), true, false, new DateTime(2023, 8, 20, 15, 37, 55, 823, DateTimeKind.Local).AddTicks(1497), "İZMİR DEMOKRASİ ÜNİVERSİTESİ", "İZMİR" },
                    { 139, "ieu.edu.tr", new DateTime(2023, 8, 20, 15, 37, 55, 823, DateTimeKind.Local).AddTicks(1502), true, false, new DateTime(2023, 8, 20, 15, 37, 55, 823, DateTimeKind.Local).AddTicks(1502), "İZMİR EKONOMİ ÜNİVERSİTESİ", "İZMİR" },
                    { 140, "ikc.edu.tr", new DateTime(2023, 8, 20, 15, 37, 55, 823, DateTimeKind.Local).AddTicks(1506), true, false, new DateTime(2023, 8, 20, 15, 37, 55, 823, DateTimeKind.Local).AddTicks(1506), "İZMİR KATİP ÇELEBİ ÜNİVERSİTESİ", "İZMİR" },
                    { 141, "", new DateTime(2023, 8, 20, 15, 37, 55, 823, DateTimeKind.Local).AddTicks(1510), true, false, new DateTime(2023, 8, 20, 15, 37, 55, 823, DateTimeKind.Local).AddTicks(1511), "İZMİR TINAZTEPE ÜNİVERSİTESİ", "İZMİR" },
                    { 142, "iyte.edu.tr", new DateTime(2023, 8, 20, 15, 37, 55, 823, DateTimeKind.Local).AddTicks(1515), true, false, new DateTime(2023, 8, 20, 15, 37, 55, 823, DateTimeKind.Local).AddTicks(1515), "İZMİR YÜKSEK TEKNOLOJİ ENSTİTÜSÜ", "İZMİR" },
                    { 143, "yasar.edu.tr", new DateTime(2023, 8, 20, 15, 37, 55, 823, DateTimeKind.Local).AddTicks(1519), true, false, new DateTime(2023, 8, 20, 15, 37, 55, 823, DateTimeKind.Local).AddTicks(1520), "YAŞAR ÜNİVERSİTESİ", "İZMİR" },
                    { 144, "kafkas.edu.tr", new DateTime(2023, 8, 20, 15, 37, 55, 823, DateTimeKind.Local).AddTicks(1524), true, false, new DateTime(2023, 8, 20, 15, 37, 55, 823, DateTimeKind.Local).AddTicks(1524), "KAFKAS ÜNİVERSİTESİ", "KARS" },
                    { 145, "kastamonu.edu.tr", new DateTime(2023, 8, 20, 15, 37, 55, 823, DateTimeKind.Local).AddTicks(1528), true, false, new DateTime(2023, 8, 20, 15, 37, 55, 823, DateTimeKind.Local).AddTicks(1528), "KASTAMONU ÜNİVERSİTESİ", "KASTAMONU" },
                    { 146, "agu.edu.tr", new DateTime(2023, 8, 20, 15, 37, 55, 823, DateTimeKind.Local).AddTicks(1532), true, false, new DateTime(2023, 8, 20, 15, 37, 55, 823, DateTimeKind.Local).AddTicks(1533), "ABDULLAH GÜL ÜNİVERSİTESİ", "KAYSERİ" },
                    { 147, "erciyes.edu.tr", new DateTime(2023, 8, 20, 15, 37, 55, 823, DateTimeKind.Local).AddTicks(1537), true, false, new DateTime(2023, 8, 20, 15, 37, 55, 823, DateTimeKind.Local).AddTicks(1537), "ERCİYES ÜNİVERSİTESİ", "KAYSERİ" },
                    { 148, "", new DateTime(2023, 8, 20, 15, 37, 55, 823, DateTimeKind.Local).AddTicks(1541), true, false, new DateTime(2023, 8, 20, 15, 37, 55, 823, DateTimeKind.Local).AddTicks(1541), "KAYSERİ ÜNİVERSİTESİ", "KAYSERİ" },
                    { 149, "nny.edu.tr", new DateTime(2023, 8, 20, 15, 37, 55, 823, DateTimeKind.Local).AddTicks(1545), true, false, new DateTime(2023, 8, 20, 15, 37, 55, 823, DateTimeKind.Local).AddTicks(1546), "NUH NACİ YAZGAN ÜNİVERSİTESİ", "KAYSERİ" },
                    { 150, "klu.edu.tr", new DateTime(2023, 8, 20, 15, 37, 55, 823, DateTimeKind.Local).AddTicks(1550), true, false, new DateTime(2023, 8, 20, 15, 37, 55, 823, DateTimeKind.Local).AddTicks(1550), "KIRKLARELİ ÜNİVERSİTESİ", "KIRKLARELİ" },
                    { 151, "ahievran.edu.tr", new DateTime(2023, 8, 20, 15, 37, 55, 823, DateTimeKind.Local).AddTicks(1554), true, false, new DateTime(2023, 8, 20, 15, 37, 55, 823, DateTimeKind.Local).AddTicks(1554), "KIRŞEHİR AHİ EVRAN ÜNİVERSİTESİ", "KIRŞEHİR" },
                    { 152, "gtu.edu.tr", new DateTime(2023, 8, 20, 15, 37, 55, 823, DateTimeKind.Local).AddTicks(1558), true, false, new DateTime(2023, 8, 20, 15, 37, 55, 823, DateTimeKind.Local).AddTicks(1559), "GEBZE TEKNİK ÜNİVERSİTESİ", "KOCAELİ" },
                    { 153, "kocaeli.edu.tr", new DateTime(2023, 8, 20, 15, 37, 55, 823, DateTimeKind.Local).AddTicks(1563), true, false, new DateTime(2023, 8, 20, 15, 37, 55, 823, DateTimeKind.Local).AddTicks(1563), "KOCAELİ ÜNİVERSİTESİ", "KOCAELİ" },
                    { 154, "gidatarim.edu.tr", new DateTime(2023, 8, 20, 15, 37, 55, 823, DateTimeKind.Local).AddTicks(1590), true, false, new DateTime(2023, 8, 20, 15, 37, 55, 823, DateTimeKind.Local).AddTicks(1590), "KONYA GIDA VE TARIM ÜNİVERSİTESİ", "KONYA" },
                    { 155, "", new DateTime(2023, 8, 20, 15, 37, 55, 823, DateTimeKind.Local).AddTicks(1595), true, false, new DateTime(2023, 8, 20, 15, 37, 55, 823, DateTimeKind.Local).AddTicks(1595), "KONYA TEKNİK ÜNİVERSİTESİ", "KONYA" },
                    { 156, "karatay.edu.tr", new DateTime(2023, 8, 20, 15, 37, 55, 823, DateTimeKind.Local).AddTicks(1600), true, false, new DateTime(2023, 8, 20, 15, 37, 55, 823, DateTimeKind.Local).AddTicks(1600), "KTO KARATAY ÜNİVERSİTESİ", "KONYA" },
                    { 157, "konya.edu.tr", new DateTime(2023, 8, 20, 15, 37, 55, 823, DateTimeKind.Local).AddTicks(1604), true, false, new DateTime(2023, 8, 20, 15, 37, 55, 823, DateTimeKind.Local).AddTicks(1604), "NECMETTİN ERBAKAN ÜNİVERSİTESİ", "KONYA" },
                    { 158, "selcuk.edu.tr", new DateTime(2023, 8, 20, 15, 37, 55, 823, DateTimeKind.Local).AddTicks(1609), true, false, new DateTime(2023, 8, 20, 15, 37, 55, 823, DateTimeKind.Local).AddTicks(1609), "SELÇUK ÜNİVERSİTESİ", "KONYA" },
                    { 159, "dpu.edu.tr", new DateTime(2023, 8, 20, 15, 37, 55, 823, DateTimeKind.Local).AddTicks(1613), true, false, new DateTime(2023, 8, 20, 15, 37, 55, 823, DateTimeKind.Local).AddTicks(1613), "KÜTAHYA DUMLUPINAR ÜNİVERSİTESİ", "KÜTAHYA" },
                    { 160, "", new DateTime(2023, 8, 20, 15, 37, 55, 823, DateTimeKind.Local).AddTicks(1618), true, false, new DateTime(2023, 8, 20, 15, 37, 55, 823, DateTimeKind.Local).AddTicks(1618), "KÜTAHYA SAĞLIK BİLİMLERİ ÜNİVERSİTESİ", "KÜTAHYA" },
                    { 161, "inonu.edu.tr", new DateTime(2023, 8, 20, 15, 37, 55, 823, DateTimeKind.Local).AddTicks(1622), true, false, new DateTime(2023, 8, 20, 15, 37, 55, 823, DateTimeKind.Local).AddTicks(1622), "İNÖNÜ ÜNİVERSİTESİ", "MALATYA" },
                    { 162, "", new DateTime(2023, 8, 20, 15, 37, 55, 823, DateTimeKind.Local).AddTicks(1627), true, false, new DateTime(2023, 8, 20, 15, 37, 55, 823, DateTimeKind.Local).AddTicks(1627), "MALATYA TURGUT ÖZAL ÜNİVERSİTESİ", "MALATYA" },
                    { 163, "cbu.edu.tr", new DateTime(2023, 8, 20, 15, 37, 55, 823, DateTimeKind.Local).AddTicks(1631), true, false, new DateTime(2023, 8, 20, 15, 37, 55, 823, DateTimeKind.Local).AddTicks(1632), "MANİSA CELÂL BAYAR ÜNİVERSİTESİ", "MANİSA" },
                    { 164, "", new DateTime(2023, 8, 20, 15, 37, 55, 823, DateTimeKind.Local).AddTicks(1636), true, false, new DateTime(2023, 8, 20, 15, 37, 55, 823, DateTimeKind.Local).AddTicks(1636), "KAHRAMANMARAŞ İSTİKLAL ÜNİVERSİTESİ", "KAHRAMANMARAŞ" },
                    { 165, "ksu.edu.tr", new DateTime(2023, 8, 20, 15, 37, 55, 823, DateTimeKind.Local).AddTicks(1640), true, false, new DateTime(2023, 8, 20, 15, 37, 55, 823, DateTimeKind.Local).AddTicks(1641), "KAHRAMANMARAŞ SÜTÇÜ İMAM ÜNİVERSİTESİ", "KAHRAMANMARAŞ" },
                    { 166, "artuklu.edu.tr", new DateTime(2023, 8, 20, 15, 37, 55, 823, DateTimeKind.Local).AddTicks(1644), true, false, new DateTime(2023, 8, 20, 15, 37, 55, 823, DateTimeKind.Local).AddTicks(1645), "MARDİN ARTUKLU ÜNİVERSİTESİ", "MARDİN" },
                    { 167, "mu.edu.tr", new DateTime(2023, 8, 20, 15, 37, 55, 823, DateTimeKind.Local).AddTicks(1649), true, false, new DateTime(2023, 8, 20, 15, 37, 55, 823, DateTimeKind.Local).AddTicks(1649), "MUĞLA SITKI KOÇMAN ÜNİVERSİTESİ", "MUĞLA" },
                    { 168, "alparslan.edu.tr", new DateTime(2023, 8, 20, 15, 37, 55, 823, DateTimeKind.Local).AddTicks(1653), true, false, new DateTime(2023, 8, 20, 15, 37, 55, 823, DateTimeKind.Local).AddTicks(1653), "MUŞ ALPARSLAN ÜNİVERSİTESİ", "MUŞ" },
                    { 169, "kapadokya.edu.tr", new DateTime(2023, 8, 20, 15, 37, 55, 823, DateTimeKind.Local).AddTicks(1657), true, false, new DateTime(2023, 8, 20, 15, 37, 55, 823, DateTimeKind.Local).AddTicks(1658), "KAPADOKYA ÜNİVERSİTESİ", "NEVŞEHİR" },
                    { 170, "nevsehir.edu.tr", new DateTime(2023, 8, 20, 15, 37, 55, 823, DateTimeKind.Local).AddTicks(1662), true, false, new DateTime(2023, 8, 20, 15, 37, 55, 823, DateTimeKind.Local).AddTicks(1662), "NEVŞEHİR HACI BEKTAŞ VELİ ÜNİVERSİTESİ", "NEVŞEHİR" },
                    { 171, "ohu.edu.tr", new DateTime(2023, 8, 20, 15, 37, 55, 823, DateTimeKind.Local).AddTicks(1666), true, false, new DateTime(2023, 8, 20, 15, 37, 55, 823, DateTimeKind.Local).AddTicks(1666), "NİĞDE ÖMER HALİSDEMİR ÜNİVERSİTESİ", "NİĞDE" },
                    { 172, "odu.edu.tr", new DateTime(2023, 8, 20, 15, 37, 55, 823, DateTimeKind.Local).AddTicks(1670), true, false, new DateTime(2023, 8, 20, 15, 37, 55, 823, DateTimeKind.Local).AddTicks(1670), "ORDU ÜNİVERSİTESİ", "ORDU" },
                    { 173, "erdogan.edu.tr", new DateTime(2023, 8, 20, 15, 37, 55, 823, DateTimeKind.Local).AddTicks(1675), true, false, new DateTime(2023, 8, 20, 15, 37, 55, 823, DateTimeKind.Local).AddTicks(1675), "RECEP TAYYİP ERDOĞAN ÜNİVERSİTESİ", "RİZE" },
                    { 174, "", new DateTime(2023, 8, 20, 15, 37, 55, 823, DateTimeKind.Local).AddTicks(1679), true, false, new DateTime(2023, 8, 20, 15, 37, 55, 823, DateTimeKind.Local).AddTicks(1679), "SAMSUN ÜNİVERSİTESİ", "RİZE" },
                    { 175, "", new DateTime(2023, 8, 20, 15, 37, 55, 823, DateTimeKind.Local).AddTicks(1684), true, false, new DateTime(2023, 8, 20, 15, 37, 55, 823, DateTimeKind.Local).AddTicks(1684), "SAKARYA UYGULAMALI BİLİMLER ÜNİVERSİTESİ", "SAKARYA" },
                    { 176, "sakarya.edu.tr", new DateTime(2023, 8, 20, 15, 37, 55, 823, DateTimeKind.Local).AddTicks(1689), true, false, new DateTime(2023, 8, 20, 15, 37, 55, 823, DateTimeKind.Local).AddTicks(1689), "SAKARYA ÜNİVERSİTESİ", "SAKARYA" },
                    { 177, "omu.edu.tr", new DateTime(2023, 8, 20, 15, 37, 55, 823, DateTimeKind.Local).AddTicks(1693), true, false, new DateTime(2023, 8, 20, 15, 37, 55, 823, DateTimeKind.Local).AddTicks(1694), "ONDOKUZ MAYIS ÜNİVERSİTESİ", "SAMSUN" },
                    { 178, "siirt.edu.tr", new DateTime(2023, 8, 20, 15, 37, 55, 823, DateTimeKind.Local).AddTicks(1698), true, false, new DateTime(2023, 8, 20, 15, 37, 55, 823, DateTimeKind.Local).AddTicks(1698), "SİİRT ÜNİVERSİTESİ", "SİİRT" },
                    { 179, "sinop.edu.tr", new DateTime(2023, 8, 20, 15, 37, 55, 823, DateTimeKind.Local).AddTicks(1702), true, false, new DateTime(2023, 8, 20, 15, 37, 55, 823, DateTimeKind.Local).AddTicks(1703), "SİNOP ÜNİVERSİTESİ", "SİNOP" },
                    { 180, "", new DateTime(2023, 8, 20, 15, 37, 55, 823, DateTimeKind.Local).AddTicks(1729), true, false, new DateTime(2023, 8, 20, 15, 37, 55, 823, DateTimeKind.Local).AddTicks(1729), "SİVAS BİLİM VE TEKNOLOJİ ÜNİVERSİTESİ", "SİVAS" },
                    { 181, "cumhuriyet.edu.tr", new DateTime(2023, 8, 20, 15, 37, 55, 823, DateTimeKind.Local).AddTicks(1735), true, false, new DateTime(2023, 8, 20, 15, 37, 55, 823, DateTimeKind.Local).AddTicks(1735), "SİVAS CUMHURİYET ÜNİVERSİTESİ", "SİVAS" },
                    { 182, "nku.edu.tr", new DateTime(2023, 8, 20, 15, 37, 55, 823, DateTimeKind.Local).AddTicks(1740), true, false, new DateTime(2023, 8, 20, 15, 37, 55, 823, DateTimeKind.Local).AddTicks(1740), "TEKİRDAĞ NAMIK KEMAL ÜNİVERSİTESİ", "TEKİRDAĞ" },
                    { 183, "gop.edu.tr", new DateTime(2023, 8, 20, 15, 37, 55, 823, DateTimeKind.Local).AddTicks(1745), true, false, new DateTime(2023, 8, 20, 15, 37, 55, 823, DateTimeKind.Local).AddTicks(1745), "TOKAT GAZİOSMANPAŞA ÜNİVERSİTESİ", "TOKAT" },
                    { 184, "avrasya.edu.tr", new DateTime(2023, 8, 20, 15, 37, 55, 823, DateTimeKind.Local).AddTicks(1749), true, false, new DateTime(2023, 8, 20, 15, 37, 55, 823, DateTimeKind.Local).AddTicks(1750), "AVRASYA ÜNİVERSİTESİ", "TRABZON" },
                    { 185, "ktu.edu.tr", new DateTime(2023, 8, 20, 15, 37, 55, 823, DateTimeKind.Local).AddTicks(1754), true, false, new DateTime(2023, 8, 20, 15, 37, 55, 823, DateTimeKind.Local).AddTicks(1754), "KARADENİZ TEKNİK ÜNİVERSİTESİ", "TRABZON" },
                    { 186, "", new DateTime(2023, 8, 20, 15, 37, 55, 823, DateTimeKind.Local).AddTicks(1758), true, false, new DateTime(2023, 8, 20, 15, 37, 55, 823, DateTimeKind.Local).AddTicks(1758), "TRABZON ÜNİVERSİTESİ", "TRABZON" },
                    { 187, "munzur.edu.tr", new DateTime(2023, 8, 20, 15, 37, 55, 823, DateTimeKind.Local).AddTicks(1762), true, false, new DateTime(2023, 8, 20, 15, 37, 55, 823, DateTimeKind.Local).AddTicks(1763), "MUNZUR ÜNİVERSİTESİ", "TUNCELİ" },
                    { 188, "harran.edu.tr", new DateTime(2023, 8, 20, 15, 37, 55, 823, DateTimeKind.Local).AddTicks(1768), true, false, new DateTime(2023, 8, 20, 15, 37, 55, 823, DateTimeKind.Local).AddTicks(1768), "HARRAN ÜNİVERSİTESİ", "ŞANLIURFA" },
                    { 189, "usak.edu.tr", new DateTime(2023, 8, 20, 15, 37, 55, 823, DateTimeKind.Local).AddTicks(1773), true, false, new DateTime(2023, 8, 20, 15, 37, 55, 823, DateTimeKind.Local).AddTicks(1773), "UŞAK ÜNİVERSİTESİ", "UŞAK" },
                    { 190, "yyu.edu.tr", new DateTime(2023, 8, 20, 15, 37, 55, 823, DateTimeKind.Local).AddTicks(1778), true, false, new DateTime(2023, 8, 20, 15, 37, 55, 823, DateTimeKind.Local).AddTicks(1778), "VAN YÜZÜNCÜ YIL ÜNİVERSİTESİ", "VAN" },
                    { 191, "bozok.edu.tr", new DateTime(2023, 8, 20, 15, 37, 55, 823, DateTimeKind.Local).AddTicks(1782), true, false, new DateTime(2023, 8, 20, 15, 37, 55, 823, DateTimeKind.Local).AddTicks(1782), "YOZGAT BOZOK ÜNİVERSİTESİ", "YOZGAT" },
                    { 192, "beun.edu.tr", new DateTime(2023, 8, 20, 15, 37, 55, 823, DateTimeKind.Local).AddTicks(1786), true, false, new DateTime(2023, 8, 20, 15, 37, 55, 823, DateTimeKind.Local).AddTicks(1787), "ZONGULDAK BÜLENT ECEVİT ÜNİVERSİTESİ", "ZONGULDAK" },
                    { 193, "aksaray.edu.tr", new DateTime(2023, 8, 20, 15, 37, 55, 823, DateTimeKind.Local).AddTicks(1791), true, false, new DateTime(2023, 8, 20, 15, 37, 55, 823, DateTimeKind.Local).AddTicks(1791), "AKSARAY ÜNİVERSİTESİ", "AKSARAY" },
                    { 194, "bayburt.edu.tr", new DateTime(2023, 8, 20, 15, 37, 55, 823, DateTimeKind.Local).AddTicks(1795), true, false, new DateTime(2023, 8, 20, 15, 37, 55, 823, DateTimeKind.Local).AddTicks(1796), "BAYBURT ÜNİVERSİTESİ", "BAYBURT" },
                    { 195, "kmu.edu.tr", new DateTime(2023, 8, 20, 15, 37, 55, 823, DateTimeKind.Local).AddTicks(1800), true, false, new DateTime(2023, 8, 20, 15, 37, 55, 823, DateTimeKind.Local).AddTicks(1800), "KARAMANOĞLU MEHMETBEY ÜNİVERSİTESİ", "KARAMAN" },
                    { 196, "kku.edu.tr", new DateTime(2023, 8, 20, 15, 37, 55, 823, DateTimeKind.Local).AddTicks(1805), true, false, new DateTime(2023, 8, 20, 15, 37, 55, 823, DateTimeKind.Local).AddTicks(1805), "KIRIKKALE ÜNİVERSİTESİ", "KIRIKKALE" },
                    { 197, "batman.edu.tr", new DateTime(2023, 8, 20, 15, 37, 55, 823, DateTimeKind.Local).AddTicks(1809), true, false, new DateTime(2023, 8, 20, 15, 37, 55, 823, DateTimeKind.Local).AddTicks(1809), "BATMAN ÜNİVERSİTESİ", "BATMAN" },
                    { 198, "sirnak.edu.tr", new DateTime(2023, 8, 20, 15, 37, 55, 823, DateTimeKind.Local).AddTicks(1813), true, false, new DateTime(2023, 8, 20, 15, 37, 55, 823, DateTimeKind.Local).AddTicks(1813), "ŞIRNAK ÜNİVERSİTESİ", "ŞIRNAK" },
                    { 199, "bartin.edu.tr", new DateTime(2023, 8, 20, 15, 37, 55, 823, DateTimeKind.Local).AddTicks(1817), true, false, new DateTime(2023, 8, 20, 15, 37, 55, 823, DateTimeKind.Local).AddTicks(1818), "BARTIN ÜNİVERSİTESİ", "BARTIN" },
                    { 200, "ardahan.edu.tr", new DateTime(2023, 8, 20, 15, 37, 55, 823, DateTimeKind.Local).AddTicks(1822), true, false, new DateTime(2023, 8, 20, 15, 37, 55, 823, DateTimeKind.Local).AddTicks(1822), "ARDAHAN ÜNİVERSİTESİ", "ARDAHAN" },
                    { 201, "igdir.edu.tr", new DateTime(2023, 8, 20, 15, 37, 55, 823, DateTimeKind.Local).AddTicks(1826), true, false, new DateTime(2023, 8, 20, 15, 37, 55, 823, DateTimeKind.Local).AddTicks(1826), "IĞDIR ÜNİVERSİTESİ", "IĞDIR" },
                    { 202, "yalova.edu.tr", new DateTime(2023, 8, 20, 15, 37, 55, 823, DateTimeKind.Local).AddTicks(1830), true, false, new DateTime(2023, 8, 20, 15, 37, 55, 823, DateTimeKind.Local).AddTicks(1831), "YALOVA ÜNİVERSİTESİ", "YALOVA" },
                    { 203, "karabuk.edu.tr", new DateTime(2023, 8, 20, 15, 37, 55, 823, DateTimeKind.Local).AddTicks(1835), true, false, new DateTime(2023, 8, 20, 15, 37, 55, 823, DateTimeKind.Local).AddTicks(1835), "KARABÜK ÜNİVERSİTESİ", "KARABÜK" },
                    { 204, "kilis.edu.tr", new DateTime(2023, 8, 20, 15, 37, 55, 823, DateTimeKind.Local).AddTicks(1839), true, false, new DateTime(2023, 8, 20, 15, 37, 55, 823, DateTimeKind.Local).AddTicks(1839), "KİLİS 7 ARALIK ÜNİVERSİTESİ", "KİLİS" },
                    { 205, "osmaniye.edu.tr", new DateTime(2023, 8, 20, 15, 37, 55, 823, DateTimeKind.Local).AddTicks(1843), true, false, new DateTime(2023, 8, 20, 15, 37, 55, 823, DateTimeKind.Local).AddTicks(1843), "OSMANİYE KORKUT ATA ÜNİVERSİTESİ", "OSMANİYE" },
                    { 206, "duzce.edu.tr", new DateTime(2023, 8, 20, 15, 37, 55, 823, DateTimeKind.Local).AddTicks(1848), true, false, new DateTime(2023, 8, 20, 15, 37, 55, 823, DateTimeKind.Local).AddTicks(1848), "DÜZCE ÜNİVERSİTESİ", "DÜZCE" }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "University",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "University",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "University",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "University",
                keyColumn: "Id",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "University",
                keyColumn: "Id",
                keyValue: 5);

            migrationBuilder.DeleteData(
                table: "University",
                keyColumn: "Id",
                keyValue: 6);

            migrationBuilder.DeleteData(
                table: "University",
                keyColumn: "Id",
                keyValue: 7);

            migrationBuilder.DeleteData(
                table: "University",
                keyColumn: "Id",
                keyValue: 8);

            migrationBuilder.DeleteData(
                table: "University",
                keyColumn: "Id",
                keyValue: 9);

            migrationBuilder.DeleteData(
                table: "University",
                keyColumn: "Id",
                keyValue: 10);

            migrationBuilder.DeleteData(
                table: "University",
                keyColumn: "Id",
                keyValue: 11);

            migrationBuilder.DeleteData(
                table: "University",
                keyColumn: "Id",
                keyValue: 12);

            migrationBuilder.DeleteData(
                table: "University",
                keyColumn: "Id",
                keyValue: 13);

            migrationBuilder.DeleteData(
                table: "University",
                keyColumn: "Id",
                keyValue: 14);

            migrationBuilder.DeleteData(
                table: "University",
                keyColumn: "Id",
                keyValue: 15);

            migrationBuilder.DeleteData(
                table: "University",
                keyColumn: "Id",
                keyValue: 16);

            migrationBuilder.DeleteData(
                table: "University",
                keyColumn: "Id",
                keyValue: 17);

            migrationBuilder.DeleteData(
                table: "University",
                keyColumn: "Id",
                keyValue: 18);

            migrationBuilder.DeleteData(
                table: "University",
                keyColumn: "Id",
                keyValue: 19);

            migrationBuilder.DeleteData(
                table: "University",
                keyColumn: "Id",
                keyValue: 20);

            migrationBuilder.DeleteData(
                table: "University",
                keyColumn: "Id",
                keyValue: 21);

            migrationBuilder.DeleteData(
                table: "University",
                keyColumn: "Id",
                keyValue: 22);

            migrationBuilder.DeleteData(
                table: "University",
                keyColumn: "Id",
                keyValue: 23);

            migrationBuilder.DeleteData(
                table: "University",
                keyColumn: "Id",
                keyValue: 24);

            migrationBuilder.DeleteData(
                table: "University",
                keyColumn: "Id",
                keyValue: 25);

            migrationBuilder.DeleteData(
                table: "University",
                keyColumn: "Id",
                keyValue: 26);

            migrationBuilder.DeleteData(
                table: "University",
                keyColumn: "Id",
                keyValue: 27);

            migrationBuilder.DeleteData(
                table: "University",
                keyColumn: "Id",
                keyValue: 28);

            migrationBuilder.DeleteData(
                table: "University",
                keyColumn: "Id",
                keyValue: 29);

            migrationBuilder.DeleteData(
                table: "University",
                keyColumn: "Id",
                keyValue: 30);

            migrationBuilder.DeleteData(
                table: "University",
                keyColumn: "Id",
                keyValue: 31);

            migrationBuilder.DeleteData(
                table: "University",
                keyColumn: "Id",
                keyValue: 32);

            migrationBuilder.DeleteData(
                table: "University",
                keyColumn: "Id",
                keyValue: 33);

            migrationBuilder.DeleteData(
                table: "University",
                keyColumn: "Id",
                keyValue: 34);

            migrationBuilder.DeleteData(
                table: "University",
                keyColumn: "Id",
                keyValue: 35);

            migrationBuilder.DeleteData(
                table: "University",
                keyColumn: "Id",
                keyValue: 36);

            migrationBuilder.DeleteData(
                table: "University",
                keyColumn: "Id",
                keyValue: 37);

            migrationBuilder.DeleteData(
                table: "University",
                keyColumn: "Id",
                keyValue: 38);

            migrationBuilder.DeleteData(
                table: "University",
                keyColumn: "Id",
                keyValue: 39);

            migrationBuilder.DeleteData(
                table: "University",
                keyColumn: "Id",
                keyValue: 40);

            migrationBuilder.DeleteData(
                table: "University",
                keyColumn: "Id",
                keyValue: 41);

            migrationBuilder.DeleteData(
                table: "University",
                keyColumn: "Id",
                keyValue: 42);

            migrationBuilder.DeleteData(
                table: "University",
                keyColumn: "Id",
                keyValue: 43);

            migrationBuilder.DeleteData(
                table: "University",
                keyColumn: "Id",
                keyValue: 44);

            migrationBuilder.DeleteData(
                table: "University",
                keyColumn: "Id",
                keyValue: 45);

            migrationBuilder.DeleteData(
                table: "University",
                keyColumn: "Id",
                keyValue: 46);

            migrationBuilder.DeleteData(
                table: "University",
                keyColumn: "Id",
                keyValue: 47);

            migrationBuilder.DeleteData(
                table: "University",
                keyColumn: "Id",
                keyValue: 48);

            migrationBuilder.DeleteData(
                table: "University",
                keyColumn: "Id",
                keyValue: 49);

            migrationBuilder.DeleteData(
                table: "University",
                keyColumn: "Id",
                keyValue: 50);

            migrationBuilder.DeleteData(
                table: "University",
                keyColumn: "Id",
                keyValue: 51);

            migrationBuilder.DeleteData(
                table: "University",
                keyColumn: "Id",
                keyValue: 52);

            migrationBuilder.DeleteData(
                table: "University",
                keyColumn: "Id",
                keyValue: 53);

            migrationBuilder.DeleteData(
                table: "University",
                keyColumn: "Id",
                keyValue: 54);

            migrationBuilder.DeleteData(
                table: "University",
                keyColumn: "Id",
                keyValue: 55);

            migrationBuilder.DeleteData(
                table: "University",
                keyColumn: "Id",
                keyValue: 56);

            migrationBuilder.DeleteData(
                table: "University",
                keyColumn: "Id",
                keyValue: 57);

            migrationBuilder.DeleteData(
                table: "University",
                keyColumn: "Id",
                keyValue: 58);

            migrationBuilder.DeleteData(
                table: "University",
                keyColumn: "Id",
                keyValue: 59);

            migrationBuilder.DeleteData(
                table: "University",
                keyColumn: "Id",
                keyValue: 60);

            migrationBuilder.DeleteData(
                table: "University",
                keyColumn: "Id",
                keyValue: 61);

            migrationBuilder.DeleteData(
                table: "University",
                keyColumn: "Id",
                keyValue: 62);

            migrationBuilder.DeleteData(
                table: "University",
                keyColumn: "Id",
                keyValue: 63);

            migrationBuilder.DeleteData(
                table: "University",
                keyColumn: "Id",
                keyValue: 64);

            migrationBuilder.DeleteData(
                table: "University",
                keyColumn: "Id",
                keyValue: 65);

            migrationBuilder.DeleteData(
                table: "University",
                keyColumn: "Id",
                keyValue: 66);

            migrationBuilder.DeleteData(
                table: "University",
                keyColumn: "Id",
                keyValue: 67);

            migrationBuilder.DeleteData(
                table: "University",
                keyColumn: "Id",
                keyValue: 68);

            migrationBuilder.DeleteData(
                table: "University",
                keyColumn: "Id",
                keyValue: 69);

            migrationBuilder.DeleteData(
                table: "University",
                keyColumn: "Id",
                keyValue: 70);

            migrationBuilder.DeleteData(
                table: "University",
                keyColumn: "Id",
                keyValue: 71);

            migrationBuilder.DeleteData(
                table: "University",
                keyColumn: "Id",
                keyValue: 72);

            migrationBuilder.DeleteData(
                table: "University",
                keyColumn: "Id",
                keyValue: 73);

            migrationBuilder.DeleteData(
                table: "University",
                keyColumn: "Id",
                keyValue: 74);

            migrationBuilder.DeleteData(
                table: "University",
                keyColumn: "Id",
                keyValue: 75);

            migrationBuilder.DeleteData(
                table: "University",
                keyColumn: "Id",
                keyValue: 76);

            migrationBuilder.DeleteData(
                table: "University",
                keyColumn: "Id",
                keyValue: 77);

            migrationBuilder.DeleteData(
                table: "University",
                keyColumn: "Id",
                keyValue: 78);

            migrationBuilder.DeleteData(
                table: "University",
                keyColumn: "Id",
                keyValue: 79);

            migrationBuilder.DeleteData(
                table: "University",
                keyColumn: "Id",
                keyValue: 80);

            migrationBuilder.DeleteData(
                table: "University",
                keyColumn: "Id",
                keyValue: 81);

            migrationBuilder.DeleteData(
                table: "University",
                keyColumn: "Id",
                keyValue: 82);

            migrationBuilder.DeleteData(
                table: "University",
                keyColumn: "Id",
                keyValue: 83);

            migrationBuilder.DeleteData(
                table: "University",
                keyColumn: "Id",
                keyValue: 84);

            migrationBuilder.DeleteData(
                table: "University",
                keyColumn: "Id",
                keyValue: 85);

            migrationBuilder.DeleteData(
                table: "University",
                keyColumn: "Id",
                keyValue: 86);

            migrationBuilder.DeleteData(
                table: "University",
                keyColumn: "Id",
                keyValue: 87);

            migrationBuilder.DeleteData(
                table: "University",
                keyColumn: "Id",
                keyValue: 88);

            migrationBuilder.DeleteData(
                table: "University",
                keyColumn: "Id",
                keyValue: 89);

            migrationBuilder.DeleteData(
                table: "University",
                keyColumn: "Id",
                keyValue: 90);

            migrationBuilder.DeleteData(
                table: "University",
                keyColumn: "Id",
                keyValue: 91);

            migrationBuilder.DeleteData(
                table: "University",
                keyColumn: "Id",
                keyValue: 92);

            migrationBuilder.DeleteData(
                table: "University",
                keyColumn: "Id",
                keyValue: 93);

            migrationBuilder.DeleteData(
                table: "University",
                keyColumn: "Id",
                keyValue: 94);

            migrationBuilder.DeleteData(
                table: "University",
                keyColumn: "Id",
                keyValue: 95);

            migrationBuilder.DeleteData(
                table: "University",
                keyColumn: "Id",
                keyValue: 96);

            migrationBuilder.DeleteData(
                table: "University",
                keyColumn: "Id",
                keyValue: 97);

            migrationBuilder.DeleteData(
                table: "University",
                keyColumn: "Id",
                keyValue: 98);

            migrationBuilder.DeleteData(
                table: "University",
                keyColumn: "Id",
                keyValue: 99);

            migrationBuilder.DeleteData(
                table: "University",
                keyColumn: "Id",
                keyValue: 100);

            migrationBuilder.DeleteData(
                table: "University",
                keyColumn: "Id",
                keyValue: 101);

            migrationBuilder.DeleteData(
                table: "University",
                keyColumn: "Id",
                keyValue: 102);

            migrationBuilder.DeleteData(
                table: "University",
                keyColumn: "Id",
                keyValue: 103);

            migrationBuilder.DeleteData(
                table: "University",
                keyColumn: "Id",
                keyValue: 104);

            migrationBuilder.DeleteData(
                table: "University",
                keyColumn: "Id",
                keyValue: 105);

            migrationBuilder.DeleteData(
                table: "University",
                keyColumn: "Id",
                keyValue: 106);

            migrationBuilder.DeleteData(
                table: "University",
                keyColumn: "Id",
                keyValue: 107);

            migrationBuilder.DeleteData(
                table: "University",
                keyColumn: "Id",
                keyValue: 108);

            migrationBuilder.DeleteData(
                table: "University",
                keyColumn: "Id",
                keyValue: 109);

            migrationBuilder.DeleteData(
                table: "University",
                keyColumn: "Id",
                keyValue: 110);

            migrationBuilder.DeleteData(
                table: "University",
                keyColumn: "Id",
                keyValue: 111);

            migrationBuilder.DeleteData(
                table: "University",
                keyColumn: "Id",
                keyValue: 112);

            migrationBuilder.DeleteData(
                table: "University",
                keyColumn: "Id",
                keyValue: 113);

            migrationBuilder.DeleteData(
                table: "University",
                keyColumn: "Id",
                keyValue: 114);

            migrationBuilder.DeleteData(
                table: "University",
                keyColumn: "Id",
                keyValue: 115);

            migrationBuilder.DeleteData(
                table: "University",
                keyColumn: "Id",
                keyValue: 116);

            migrationBuilder.DeleteData(
                table: "University",
                keyColumn: "Id",
                keyValue: 117);

            migrationBuilder.DeleteData(
                table: "University",
                keyColumn: "Id",
                keyValue: 118);

            migrationBuilder.DeleteData(
                table: "University",
                keyColumn: "Id",
                keyValue: 119);

            migrationBuilder.DeleteData(
                table: "University",
                keyColumn: "Id",
                keyValue: 120);

            migrationBuilder.DeleteData(
                table: "University",
                keyColumn: "Id",
                keyValue: 121);

            migrationBuilder.DeleteData(
                table: "University",
                keyColumn: "Id",
                keyValue: 122);

            migrationBuilder.DeleteData(
                table: "University",
                keyColumn: "Id",
                keyValue: 123);

            migrationBuilder.DeleteData(
                table: "University",
                keyColumn: "Id",
                keyValue: 124);

            migrationBuilder.DeleteData(
                table: "University",
                keyColumn: "Id",
                keyValue: 125);

            migrationBuilder.DeleteData(
                table: "University",
                keyColumn: "Id",
                keyValue: 126);

            migrationBuilder.DeleteData(
                table: "University",
                keyColumn: "Id",
                keyValue: 127);

            migrationBuilder.DeleteData(
                table: "University",
                keyColumn: "Id",
                keyValue: 128);

            migrationBuilder.DeleteData(
                table: "University",
                keyColumn: "Id",
                keyValue: 129);

            migrationBuilder.DeleteData(
                table: "University",
                keyColumn: "Id",
                keyValue: 130);

            migrationBuilder.DeleteData(
                table: "University",
                keyColumn: "Id",
                keyValue: 131);

            migrationBuilder.DeleteData(
                table: "University",
                keyColumn: "Id",
                keyValue: 132);

            migrationBuilder.DeleteData(
                table: "University",
                keyColumn: "Id",
                keyValue: 133);

            migrationBuilder.DeleteData(
                table: "University",
                keyColumn: "Id",
                keyValue: 134);

            migrationBuilder.DeleteData(
                table: "University",
                keyColumn: "Id",
                keyValue: 135);

            migrationBuilder.DeleteData(
                table: "University",
                keyColumn: "Id",
                keyValue: 136);

            migrationBuilder.DeleteData(
                table: "University",
                keyColumn: "Id",
                keyValue: 137);

            migrationBuilder.DeleteData(
                table: "University",
                keyColumn: "Id",
                keyValue: 138);

            migrationBuilder.DeleteData(
                table: "University",
                keyColumn: "Id",
                keyValue: 139);

            migrationBuilder.DeleteData(
                table: "University",
                keyColumn: "Id",
                keyValue: 140);

            migrationBuilder.DeleteData(
                table: "University",
                keyColumn: "Id",
                keyValue: 141);

            migrationBuilder.DeleteData(
                table: "University",
                keyColumn: "Id",
                keyValue: 142);

            migrationBuilder.DeleteData(
                table: "University",
                keyColumn: "Id",
                keyValue: 143);

            migrationBuilder.DeleteData(
                table: "University",
                keyColumn: "Id",
                keyValue: 144);

            migrationBuilder.DeleteData(
                table: "University",
                keyColumn: "Id",
                keyValue: 145);

            migrationBuilder.DeleteData(
                table: "University",
                keyColumn: "Id",
                keyValue: 146);

            migrationBuilder.DeleteData(
                table: "University",
                keyColumn: "Id",
                keyValue: 147);

            migrationBuilder.DeleteData(
                table: "University",
                keyColumn: "Id",
                keyValue: 148);

            migrationBuilder.DeleteData(
                table: "University",
                keyColumn: "Id",
                keyValue: 149);

            migrationBuilder.DeleteData(
                table: "University",
                keyColumn: "Id",
                keyValue: 150);

            migrationBuilder.DeleteData(
                table: "University",
                keyColumn: "Id",
                keyValue: 151);

            migrationBuilder.DeleteData(
                table: "University",
                keyColumn: "Id",
                keyValue: 152);

            migrationBuilder.DeleteData(
                table: "University",
                keyColumn: "Id",
                keyValue: 153);

            migrationBuilder.DeleteData(
                table: "University",
                keyColumn: "Id",
                keyValue: 154);

            migrationBuilder.DeleteData(
                table: "University",
                keyColumn: "Id",
                keyValue: 155);

            migrationBuilder.DeleteData(
                table: "University",
                keyColumn: "Id",
                keyValue: 156);

            migrationBuilder.DeleteData(
                table: "University",
                keyColumn: "Id",
                keyValue: 157);

            migrationBuilder.DeleteData(
                table: "University",
                keyColumn: "Id",
                keyValue: 158);

            migrationBuilder.DeleteData(
                table: "University",
                keyColumn: "Id",
                keyValue: 159);

            migrationBuilder.DeleteData(
                table: "University",
                keyColumn: "Id",
                keyValue: 160);

            migrationBuilder.DeleteData(
                table: "University",
                keyColumn: "Id",
                keyValue: 161);

            migrationBuilder.DeleteData(
                table: "University",
                keyColumn: "Id",
                keyValue: 162);

            migrationBuilder.DeleteData(
                table: "University",
                keyColumn: "Id",
                keyValue: 163);

            migrationBuilder.DeleteData(
                table: "University",
                keyColumn: "Id",
                keyValue: 164);

            migrationBuilder.DeleteData(
                table: "University",
                keyColumn: "Id",
                keyValue: 165);

            migrationBuilder.DeleteData(
                table: "University",
                keyColumn: "Id",
                keyValue: 166);

            migrationBuilder.DeleteData(
                table: "University",
                keyColumn: "Id",
                keyValue: 167);

            migrationBuilder.DeleteData(
                table: "University",
                keyColumn: "Id",
                keyValue: 168);

            migrationBuilder.DeleteData(
                table: "University",
                keyColumn: "Id",
                keyValue: 169);

            migrationBuilder.DeleteData(
                table: "University",
                keyColumn: "Id",
                keyValue: 170);

            migrationBuilder.DeleteData(
                table: "University",
                keyColumn: "Id",
                keyValue: 171);

            migrationBuilder.DeleteData(
                table: "University",
                keyColumn: "Id",
                keyValue: 172);

            migrationBuilder.DeleteData(
                table: "University",
                keyColumn: "Id",
                keyValue: 173);

            migrationBuilder.DeleteData(
                table: "University",
                keyColumn: "Id",
                keyValue: 174);

            migrationBuilder.DeleteData(
                table: "University",
                keyColumn: "Id",
                keyValue: 175);

            migrationBuilder.DeleteData(
                table: "University",
                keyColumn: "Id",
                keyValue: 176);

            migrationBuilder.DeleteData(
                table: "University",
                keyColumn: "Id",
                keyValue: 177);

            migrationBuilder.DeleteData(
                table: "University",
                keyColumn: "Id",
                keyValue: 178);

            migrationBuilder.DeleteData(
                table: "University",
                keyColumn: "Id",
                keyValue: 179);

            migrationBuilder.DeleteData(
                table: "University",
                keyColumn: "Id",
                keyValue: 180);

            migrationBuilder.DeleteData(
                table: "University",
                keyColumn: "Id",
                keyValue: 181);

            migrationBuilder.DeleteData(
                table: "University",
                keyColumn: "Id",
                keyValue: 182);

            migrationBuilder.DeleteData(
                table: "University",
                keyColumn: "Id",
                keyValue: 183);

            migrationBuilder.DeleteData(
                table: "University",
                keyColumn: "Id",
                keyValue: 184);

            migrationBuilder.DeleteData(
                table: "University",
                keyColumn: "Id",
                keyValue: 185);

            migrationBuilder.DeleteData(
                table: "University",
                keyColumn: "Id",
                keyValue: 186);

            migrationBuilder.DeleteData(
                table: "University",
                keyColumn: "Id",
                keyValue: 187);

            migrationBuilder.DeleteData(
                table: "University",
                keyColumn: "Id",
                keyValue: 188);

            migrationBuilder.DeleteData(
                table: "University",
                keyColumn: "Id",
                keyValue: 189);

            migrationBuilder.DeleteData(
                table: "University",
                keyColumn: "Id",
                keyValue: 190);

            migrationBuilder.DeleteData(
                table: "University",
                keyColumn: "Id",
                keyValue: 191);

            migrationBuilder.DeleteData(
                table: "University",
                keyColumn: "Id",
                keyValue: 192);

            migrationBuilder.DeleteData(
                table: "University",
                keyColumn: "Id",
                keyValue: 193);

            migrationBuilder.DeleteData(
                table: "University",
                keyColumn: "Id",
                keyValue: 194);

            migrationBuilder.DeleteData(
                table: "University",
                keyColumn: "Id",
                keyValue: 195);

            migrationBuilder.DeleteData(
                table: "University",
                keyColumn: "Id",
                keyValue: 196);

            migrationBuilder.DeleteData(
                table: "University",
                keyColumn: "Id",
                keyValue: 197);

            migrationBuilder.DeleteData(
                table: "University",
                keyColumn: "Id",
                keyValue: 198);

            migrationBuilder.DeleteData(
                table: "University",
                keyColumn: "Id",
                keyValue: 199);

            migrationBuilder.DeleteData(
                table: "University",
                keyColumn: "Id",
                keyValue: 200);

            migrationBuilder.DeleteData(
                table: "University",
                keyColumn: "Id",
                keyValue: 201);

            migrationBuilder.DeleteData(
                table: "University",
                keyColumn: "Id",
                keyValue: 202);

            migrationBuilder.DeleteData(
                table: "University",
                keyColumn: "Id",
                keyValue: 203);

            migrationBuilder.DeleteData(
                table: "University",
                keyColumn: "Id",
                keyValue: 204);

            migrationBuilder.DeleteData(
                table: "University",
                keyColumn: "Id",
                keyValue: 205);

            migrationBuilder.DeleteData(
                table: "University",
                keyColumn: "Id",
                keyValue: 206);
        }
    }
}
