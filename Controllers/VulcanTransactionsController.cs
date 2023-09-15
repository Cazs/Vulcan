using CsvHelper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Text;
using Vulcan.DAL;
using Vulcan.Models;

namespace Vulcan.Controllers
{
    public class VulcanTransactionsController : Controller
    {
        private readonly VulcanTransactionContext _context;

        public VulcanTransactionsController(VulcanTransactionContext context)
        {
            _context = context;
        }

        // GET: VulcanTransactions
        public async Task<IActionResult> Index()
        {
            ViewData["Transactions"] = _context.VulcanTransaction != null ?
                          View(await _context.VulcanTransaction.ToListAsync()) :
                          Problem("Entity set 'VulcanTransactionContext.VulcanTransaction'  is null.");
            return View();
        }

        // GET: VulcanTransactions/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.VulcanTransaction == null)
            {
                return NotFound();
            }

            var vulcanTransaction = await _context.VulcanTransaction
                .FirstOrDefaultAsync(m => m.Id == id);
            if (vulcanTransaction == null)
            {
                return NotFound();
            }

            return View(vulcanTransaction);
        }

        // GET: VulcanTransactions/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: VulcanTransactions/Create
        [HttpPost]
        public async Task<IActionResult> Create(IFormFile CsvFile)
        {
            long size = CsvFile.Length;

            System.Console.WriteLine("File Size: " + size);

            var result = new StringBuilder();
            List<VulcanTransaction> transactions = new List<VulcanTransaction>();

            using (var reader = new StreamReader(CsvFile.OpenReadStream()))
            {
                int lineCount = 0;
                while (reader.Peek() >= 0)
                {
                    string line = await reader.ReadLineAsync();
                    string[] cols = line.Split(",");

                    if (lineCount > 0)
                    {
                        VulcanTransaction vulcanTransaction = new VulcanTransaction
                        {
                            Id = int.Parse(cols[0]),
                            AccountHolder = cols[1],
                            BranchCode = int.Parse(cols[2]),
                            AccountNumber = long.Parse(cols[3]),
                            AccountType = int.Parse(cols[4]),
                            TransactionDate = DateTime.ParseExact(cols[5], "dd/MM/yyyy", null), //  DateTime.Parse(cols[5]),  HH:mm
                            Amount = decimal.Parse(cols[6]),
                            Status = int.Parse(cols[7]),
                            EffectiveStatusDate = DateTime.ParseExact(cols[8], "dd/MM/yyyy", null),
                        };

                        if (vulcanTransaction != null)
                        {
                            transactions.Add(vulcanTransaction);
                            result.AppendLine(line);
                            _context.VulcanTransaction.Add(vulcanTransaction);
                        }
                    }
                    else
                    {
                        ++lineCount;
                    }
                }
            }

            System.Console.WriteLine("File Contents:\n\n" + result.ToString());

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        // GET: VulcanTransactions
        /*public async Task<IActionResult> Report()
        {
            ViewData["Transactions"] = _reportContext.VulcanTransactionReport != null ?
                          View(await _reportContext.VulcanTransactionReport.ToListAsync()) :
                          Problem("Entity set 'VulcanTransactionReportContext.VulcanTransactionReport'  is null.");
            return View();
        }*/

        // POST: VulcanTransactions/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        /*[HttpPost]
        [ValidateAntiForgeryToken]
        public Task<IActionResult> UploadCsv([Bind("Id")] VulcanTransaction vulcanTransaction)
        {
            if (ModelState.IsValid)
            {
                /*_context.Add(vulcanTransaction);
                await _context.SaveChangesAsync();*

                using (var reader = new StreamReader("test.csv"))
                using (var csv = new CsvReader(reader, CultureInfo.InvariantCulture))
                {
                    var records = csv.GetRecords<dynamic>();
                    foreach (var record in records)
                    {
                        System.Console.WriteLine("Record: " + record);
                    }
                }

                return Task.FromResult<IActionResult>(RedirectToAction(nameof(Index)));
            }
            return Task.FromResult<IActionResult>(View(vulcanTransaction));
        }*/

        // GET: VulcanTransactions/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.VulcanTransaction == null)
            {
                return NotFound();
            }

            var vulcanTransaction = await _context.VulcanTransaction.FindAsync(id);
            if (vulcanTransaction == null)
            {
                return NotFound();
            }
            return View(vulcanTransaction);
        }

        // POST: VulcanTransactions/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id")] VulcanTransaction vulcanTransaction)
        {
            if (id != vulcanTransaction.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(vulcanTransaction);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!VulcanTransactionExists(vulcanTransaction.Id))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction(nameof(Index));
            }
            return View(vulcanTransaction);
        }

        // GET: VulcanTransactions/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.VulcanTransaction == null)
            {
                return NotFound();
            }

            var vulcanTransaction = await _context.VulcanTransaction
                .FirstOrDefaultAsync(m => m.Id == id);
            if (vulcanTransaction == null)
            {
                return NotFound();
            }

            return View(vulcanTransaction);
        }

        // POST: VulcanTransactions/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.VulcanTransaction == null)
            {
                return Problem("Entity set 'VulcanTransactionContext.VulcanTransaction'  is null.");
            }
            var vulcanTransaction = await _context.VulcanTransaction.FindAsync(id);
            if (vulcanTransaction != null)
            {
                _context.VulcanTransaction.Remove(vulcanTransaction);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool VulcanTransactionExists(int id)
        {
            return (_context.VulcanTransaction?.Any(e => e.Id == id)).GetValueOrDefault();
        }
    }
}
